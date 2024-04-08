#include <SPI.h>
#include <Ethernet.h>
#include <LiquidCrystal_I2C.h>
#include <Stepper.h>
#include <ArduinoJson.h>

// Variáveis do Software e Máquina
const int sensorPin = 9;
const int led_Operacional = 8; // Ligado
const int led_Ocioso = 6;      // Sem leitura Esteira
const int led_Parada = 7;      // Interrompido/Desligado

const size_t JSON_CAPACITY = 2;
unsigned long ultimaLeituraDados = 0;
const unsigned long intervaloLeituraDados = 100; // Tempo (ms) Leitura no Servidor

int quantidadePecas;
int operatingSensorValue;
int idleSensorValue;
int stopSensorValue;
int motorSensorValue;
int motorSpeedValue;

// Configurações de rede
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192, 168, 1, 100); // IP Arduino
IPAddress serverIP(192, 168, 1, 1); // IP Servidor de dados: Sensors.json
int serverPort = 80;
EthernetClient client;

// Instancia Display LCD
#define addressDisplay 0x27
#define columns 16
#define lines 2
LiquidCrystal_I2C lcd(addressDisplay, columns, lines);

// Instancia Motor
const int steps = 2000;
Stepper stepper(steps, 2, 3, 4, 5);

// Protótipos de função
void informacaoLCD(const char* mensagem);
void conectarServidor();
void lerDadosServidor();
void controleEstado();
void controleMotor(int operacaoSensor, int motorSensor);
void controleSensorPecas();
void controleOperacaoProducao();
void testeLuzes();

void setup() {
  Serial.begin(9600);
  pinMode(10, OUTPUT); // Setar o pino 10 como saída para o Ethernet Shield
  digitalWrite(10, HIGH); // Ativar o Ethernet Shield
  Ethernet.begin(mac, ip); // Iniciar a conexão Ethernet
  delay(2000); // Espera a inicialização Ethernet

  pinMode(sensorPin, INPUT);
  pinMode(led_Operacional, OUTPUT);
  pinMode(led_Ocioso, OUTPUT);
  pinMode(led_Parada, OUTPUT);

  informacaoLCD("Conectando");
// Conectar ao servidor
  if (!client.connect(serverIP, serverPort)) {
    informacaoLCD("Falha Conexao");
    return;
  }
  // Envia solicitação GET para obter dados
  client.println("GET /Sensors.json HTTP/1.1");
  client.println("Host: 192.168.1.1");
  client.println("Connection: close");
  client.println();
  // Executa teste de luzes informativas do estado da máquina
  informacaoLCD("Acionando Luzes");
  testeLuzes();
}

void loop() {
  unsigned long tempoAtual = millis();
  // Verifica Tempo Leitura dos dados do Servidor
  if (tempoAtual - ultimaLeituraDados >= intervaloLeituraDados) {
    ultimaLeituraDados = tempoAtual;
    lerDadosServidor();
  }
  // Controles da máquina de acordo com os status
  controleEstado();
  // Controla Motor de acordo com o status
  controleMotor(operatingSensorValue, motorSensorValue);
 // Controla Leitura do Sensor indutivo e Produção
  controleSensorPecas();
  controleOperacaoProducao();
} 

void lerDadosServidor() {
  if (!client.connected()) {
    // Se não estiver conectado, reconecte-se ao servidor
    if (!client.connect(serverIP, serverPort)) {
      informacaoLCD("Falha Conexao");
      return;
    }
    // Envie uma solicitação GET para obter o JSON
    client.println("GET /Sensors.json HTTP/1.1");
    client.println("Host: 192.168.1.1");
    client.println("Connection: close");
    client.println();
  }

  bool httpBodyStarted = false;
  String response = "";

  while (client.available()) {
    char c = client.read();

    if (!httpBodyStarted && (c == '\r' || c == '\n')) {
      continue;
    }

    if (!httpBodyStarted && (c == '{' || c == '[')) {
      httpBodyStarted = true;
    }

    if (httpBodyStarted) {
      response += c;
    }
  }

  StaticJsonDocument<JSON_CAPACITY> jsonDocument;
  // Ler o JSON a partir da resposta
  DeserializationError error = deserializeJson(jsonDocument, response);

  // Verificar se as chaves necessárias estão presentes no JSON
  if (!jsonDocument.containsKey("OperatingSensor") &&
      !jsonDocument.containsKey("IdleSensor") && 
      !jsonDocument.containsKey("StopSensor") &&
      !jsonDocument.containsKey("MotorSensor") &&
      !jsonDocument.containsKey("Speed")) {
    return;
  }
  // Extrair os valores dos sensores
  operatingSensorValue = jsonDocument["OperatingSensor"].as<int>();
  idleSensorValue = jsonDocument["IdleSensor"].as<int>();
  stopSensorValue = jsonDocument["StopSensor"].as<int>();
  motorSensorValue = jsonDocument["MotorSensor"].as<int>();
  motorSpeedValue = jsonDocument["Speed"].as<int>();
  // Fechar a conexão com o servidor
  client.stop();
}

void enviarDadosServidor() {
  if (client.connect(serverIP, serverPort)) {
    String requestBody = "{ \"QuantityPieces\": " + String(quantidadePecas) + " }";

    client.println("POST /update_production_json.aspx HTTP/1.1");
    client.println("Host: 192.168.1.1");
    client.println("Content-Type: application/json");
    client.println("Content-Length: " + String(requestBody.length()));
    client.println();
    client.println(requestBody);
    client.stop(); // Encerra a conexão após enviar os dados
  }
}

void controleEstado() {
  if (operatingSensorValue == 1 && idleSensorValue == 0 && stopSensorValue == 0) {
    digitalWrite(led_Operacional, HIGH);
    digitalWrite(led_Ocioso, LOW);
    digitalWrite(led_Parada, LOW);
    informacaoLCD("Maquina operacional");
  } 
  else if (operatingSensorValue == 1 && idleSensorValue == 1 && stopSensorValue == 0) {
    digitalWrite(led_Operacional, LOW);
    digitalWrite(led_Ocioso, HIGH);
    digitalWrite(led_Parada, LOW);
    informacaoLCD("Maquina ociosa: Sem Leitura");
  } 
  else if (operatingSensorValue == 0 && idleSensorValue == 0 && stopSensorValue == 1) {
    digitalWrite(led_Operacional, LOW);
    digitalWrite(led_Ocioso, LOW);
    digitalWrite(led_Parada, HIGH);
    informacaoLCD("Maquina em Parada");
  }
  else if (operatingSensorValue == 0 && idleSensorValue == 0 && stopSensorValue == 2) { // Parada de Emergência
    for (int i = 0; i < 4; i++) {
      digitalWrite(led_Operacional, LOW);
      digitalWrite(led_Ocioso, LOW);
      digitalWrite(led_Parada, HIGH);
      delay(200);
      digitalWrite(led_Ocioso, LOW);
      digitalWrite(led_Parada, LOW);
      digitalWrite(led_Operacional, LOW);
      delay(200);
      digitalWrite(led_Operacional, LOW);
      digitalWrite(led_Ocioso, LOW);
      digitalWrite(led_Parada, HIGH);
      delay(200);
    }
    informacaoLCD("Parada de Emergencia");
  }
}

void controleMotor(int operacaoSensor, int motorSensor) {
  if (operacaoSensor == 1 && motorSensor == 1) {
    stepper.setSpeed(motorSpeedValue); // Velocidade
    stepper.step(steps);
  } else {
    stepper.step(0); // Para o motor
  }
}

void controleSensorPecas() {
  int valorSensor = digitalRead(sensorPin);
  // Atualiza estado da máquina com base no valor do Sensor indutivo
  if (operatingSensorValue == 1 && stopSensorValue == 0 && valorSensor == HIGH) {
    operatingSensorValue = 1;
    idleSensorValue = 0;
    stopSensorValue = 0;
  } else {
    operatingSensorValue = 0;
    idleSensorValue = 1;
    stopSensorValue = 0;
  }
}

void controleOperacaoProducao() {
  unsigned long tempoAtual = millis();
  int valorSensor = digitalRead(sensorPin);

  // Controle baseado no valor do sensor e estado máquina
  if (operatingSensorValue == 1 && idleSensorValue == 0 && stopSensorValue == 0 && valorSensor == HIGH) {
    // Inicia a contagem de peças
    char contagemPecas[20];
    snprintf(contagemPecas, sizeof(contagemPecas), "Pecas Lidas: %d", quantidadePecas);
    informacaoLCD(contagemPecas);

    // Contabiliza e envia os dados
    quantidadePecas++;
    enviarDadosServidor();
  }
  else {
    // Atualiza o estado da máquina se a máquina estava operando
    if (operatingSensorValue == 1 && tempoAtual) {
      operatingSensorValue = 0;
      idleSensorValue = 1;
      stopSensorValue = 0;
    }
    // Verifica se o sensor está ativo e atualiza o estado
    if (valorSensor == HIGH) {
      operatingSensorValue = 1;
      idleSensorValue = 0;
      stopSensorValue = 0;
    }
  }
}

void informacaoLCD(const char* mensagem) {
  lcd.begin(columns, lines);
  lcd.backlight();
  lcd.clear();

  if (strcmp(mensagem, "Maquina operacional") == 0) {
    lcd.setCursor(0, 0);
    lcd.print("Maquina");
    lcd.setCursor(0, 1);
    lcd.print("operacional");
  } else if (strcmp(mensagem, "Maquina ociosa: Sem Leitura") == 0) {
    lcd.setCursor(0, 0);
    lcd.print("Maquina ociosa:");
    lcd.setCursor(0, 1);
    lcd.print("Sem Leitura");
  } else if (strncmp(mensagem, "Maquina em Parada", 17) == 0) {
    lcd.setCursor(0, 0);
    lcd.print("Maquina em");
    lcd.setCursor(0, 1);
    lcd.print("Parada");
  } else if (strncmp(mensagem, "Parada de Emergencia", 20) == 0) {
    lcd.setCursor(0, 0);
    lcd.print("Parada de");
    lcd.setCursor(0, 1);
    lcd.print("Emergencia");
  } else if (strncmp(mensagem, "Pecas Lidas:", 12) == 0) {
    lcd.setCursor(0, 0);
    lcd.print("Pecas Lidas:");
    lcd.setCursor(0, 1);
    lcd.print(mensagem + 12);
  } else {
    lcd.print(mensagem);
  }
}

void testeLuzes() {
  for (int i = 0; i < 4; i++) {
    digitalWrite(led_Ocioso, HIGH);
    digitalWrite(led_Parada, HIGH);
    digitalWrite(led_Operacional, HIGH);
    delay(500);
    digitalWrite(led_Ocioso, LOW);
    digitalWrite(led_Parada, LOW);
    digitalWrite(led_Operacional, LOW);
    delay(500);
  }
}