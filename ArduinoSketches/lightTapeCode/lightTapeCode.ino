#include <avr/sleep.h>
#define DELAY_BETWEEN_MODES 20 // Задержка в миллисекундах между шагами 
// Порты, на которых висят светодиоды и кнопка.
byte pinBtn   = 12; // Кнопка на 12 пине.
byte pinRed   = 5;  // Красные светодиоды на 5 пине.
byte pinGreen = 6;  // Зеленые светодиоды на 6 пине.
byte pinBlue  = 3;  // Синие светодиоды на 3 пине.
long tempMillis = 0; // Задержка в миллисекундах перед выводом инфы на последовательный порт
static byte mode = 1;   // Номер текущего эффекта.
boolean isButtonPushed = false;
static int state = 0;
static int index = 0;

void setup()
{
  pinMode(pinBtn, INPUT_PULLUP);
  Serial.begin(9600);
}

void loop()
{
  printModeNumber();
  if (digitalRead(pinBtn)==0 && !isButtonPushed)
  {
    isButtonPushed = true;
      mode++;
      if (mode > 10) mode = 1;
      state = 0;
      index = 0;
      switchLightsOff();
      set_sleep_mode(SLEEP_MODE_IDLE);
      sleep_mode();
  }
  if(digitalRead(pinBtn)==1) 
        isButtonPushed = false;
  switch (mode)
  {
    case 1: mode1(); break;
    case 2: mode2(); break;
    case 3: mode3(); break;
    case 4: mode4(); break;
    case 5: mode5(); break;        
    case 6: mode6(); break;                
    case 7: mode7(); break;
    default: modeDefault(); break;
  }
  delay(DELAY_BETWEEN_MODES);
}

void switchLightsOff(){
  analogWrite(pinRed,   255);
  analogWrite(pinGreen, 255);
  analogWrite(pinBlue,  255);
}

void printModeNumber(){
  while(millis()-tempMillis>100){
    Serial.print("mode: ");
    Serial.print(mode);
    Serial.print(" state : ");
    Serial.println(state);
    tempMillis = millis();
  }
}

void mode1(){
  analogWrite(pinRed,   random(0, 255));
  analogWrite(pinGreen, random(0, 255));
  analogWrite(pinBlue,  random(0, 255));
  delay(DELAY_BETWEEN_MODES);
}

void mode2(){
  if (state == 3)
    {
      analogWrite(pinRed,   255);
      analogWrite(pinGreen, 0);
    }
  if (state == 6)
    {
      analogWrite(pinBlue, 255);
      analogWrite(pinRed,  0);
    }
  if (state == 9)
    {
      analogWrite(pinGreen, 255);
      analogWrite(pinBlue,  0);
    }
  state--;
  if (state < 1) state = 9;
  delay(DELAY_BETWEEN_MODES);
}

void mode3(){
  if (state == 1)
    {
      analogWrite(pinBlue,  255);
      analogWrite(pinGreen, 0);
    }
  if (state == 4)
    {
      analogWrite(pinGreen, 255);
      analogWrite(pinRed,   0);
    }
  if (state == 7)
    {
      analogWrite(pinRed,  255);
      analogWrite(pinBlue, 0);
    }
  state++;
  if (state > 9) state = 1;
  delay(DELAY_BETWEEN_MODES);
}

void mode4(){
  if (state == 0)
    {  
      analogWrite(pinBlue, index);
      analogWrite(pinGreen, 255 - index);
    }
  if (state == 1)
    {
      analogWrite(pinGreen, index);
      analogWrite(pinRed, 255 - index);
    }
  if (state == 2)
    {
      analogWrite(pinRed, index);
      analogWrite(pinBlue, 255 - index);
    }
  index += 5;
  if (index > 255)
    {
      state++;
      index = 0;
      if (state > 2) 
        state = 0;
    }
}

void mode5(){
  analogWrite(pinRed,   0);
  analogWrite(pinGreen, 0);
  analogWrite(pinBlue,  0);
}

void mode6(){
  analogWrite(pinRed,   255);
  analogWrite(pinGreen, 255);
  analogWrite(pinBlue,  255);
}

void mode7(){
 analogWrite(pinGreen, 2);
}

void modeDefault(){
 analogWrite(pinGreen, 230);
 analogWrite(pinRed, 230);
 analogWrite(pinBlue, 230);
}
