#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>

#ifndef APSSID
#define APSSID "ESPap"
#define APPSK  "espapapap"
#endif

const char adminPage[] PROGMEM = 
    "<html>"
      "<body>"
       "<a href='/on' style='font-size: 35px; margin: 50px'>Turn on</a>"
       "<br><br><br>"
       "<a href='/off' style='font-size: 35px; margin: 50px'>Turn off</a>"
       "<br><br><br>"
       "<a href='/toggle' style='font-size: 35px; margin: 50px'>Toggle</a>"
       "<br><br><br>"
      "</body>"
    "</html>";
    
/* Set these to your desired credentials. */
const char *ssid = APSSID;
const char *password = APPSK;

ESP8266WebServer server(80);

/* Just a little test message.  Go to http://192.168.4.1 in a web browser
   connected to this access point to see it.
*/
void switch_led_on(){
  digitalWrite(LED_BUILTIN, 0);
  server.send(200, "text/html", adminPage);
}

void switch_led_off(){
  digitalWrite(LED_BUILTIN, 1);
  server.send(200, "text/html", adminPage);
}

void toggle_led(){
  digitalWrite(LED_BUILTIN, 1-digitalRead(LED_BUILTIN));
  server.send(200, "text/html", adminPage);
}

void led_blink(){
  server.send(200, "text/html", "<h1>Led is blinking</h1>");
  for(int i=0;i<50;i++){
    digitalWrite(LED_BUILTIN, 0);
    delay(400);
    digitalWrite(LED_BUILTIN, 1);
    delay(400);
  }
}
void handleRoot() {
  server.on("/on", switch_led_on);
  server.on("/off", switch_led_off);
  server.on("/toggle", toggle_led);
  server.send(200, "text/html", adminPage);
}

void setup() {
  delay(1000);
  pinMode(LED_BUILTIN,OUTPUT);
  Serial.begin(115200);
  Serial.println();
  Serial.print("Configuring access point...");
  /* You can remove the password parameter if you want the AP to be open. */
  WiFi.softAP(ssid, password);

  IPAddress myIP = WiFi.softAPIP();
  Serial.print("AP IP address: ");
  Serial.println(myIP);
  server.on("/", handleRoot);
  server.begin();
  Serial.println("HTTP server started");
}

void loop() {
  server.handleClient();
}
