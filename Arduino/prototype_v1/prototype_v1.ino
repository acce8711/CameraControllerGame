
int picture_button_pin = 5;
int camera_speed_pin = A2;

int camera_speed_val = 0;
int mapped_camera_speed = 0;

int picture_button_val = 1;
int prev_picture_button_val = 1;

int mapped_camera_rotation = 0;

unsigned long last_time = 0;

int delay_num = 100;

//Commands
const String TAKE_PICTURE = "takePicture";
const String ADJUST_SPEED = "adjustSpeed";
const String ROTATE_CAMERA = "rotateCamera";

void setup() {
  // put your setup code here, to run once:
  pinMode(picture_button_pin, INPUT_PULLUP);
  pinMode(camera_speed_pin, INPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  //MonitorPictureTaking(picture_button_val, prev_picture_button_val);
  //MonitorCameraSpeed(camera_speed_val, mapped_camera_speed);
  MonitorCameraRotation(camera_speed_val, mapped_camera_speed);


  //Serial.println("Pot value: " + String(pot_val));

  
  delay(delay_num);


    // Print a heartbeat
  // if (millis() > last_time + 2000)
  // {
  // Serial.println("Arduino is alive!!");
  // last_time = millis();
  // }
  // // Send some message when I receive an 'A' or a 'Z'.
  // switch (Serial.read())
  // {
  // case 'A':
  // Serial.println("That's the first letter of the abecedarium.");
  // break;
  // case 'Z':
  // Serial.println("That's the last letter of the abecedarium.");
  // break;
  // }
}

void MonitorPictureTaking(int &picture_button_val, int &prev_picture_button_val) {
  picture_button_val = digitalRead(picture_button_pin);

  if(prev_picture_button_val == 1 && picture_button_val == 0) {
    Serial.println(String(TAKE_PICTURE));
  }

  prev_picture_button_val = picture_button_val;   
}

void MonitorCameraSpeed(int &camera_speed_val, int &mapped_camera_speed) {
  long avg_cam_speed = analogRead(camera_speed_pin);
  for(int i = 0; i< 10; i++) {
    avg_cam_speed =  avg_cam_speed + analogRead(camera_speed_pin);
  }
  camera_speed_val = avg_cam_speed / 11;
  //Serial.println(camera_speed_val);

  int mapped_speed = ceil((3./1023. * camera_speed_val) + 1.);

  if(mapped_speed != mapped_camera_speed){
    mapped_camera_speed = mapped_speed;
    Serial.println(ADJUST_SPEED + "," + mapped_camera_speed);
  }
}

//temp
void MonitorCameraRotation(int &camera_speed_val, int &mapped_camera_speed) {
  long avg_cam_speed = analogRead(camera_speed_pin);
  for(int i = 0; i< 10; i++) {
    avg_cam_speed =  avg_cam_speed + analogRead(camera_speed_pin);
  }
  camera_speed_val = avg_cam_speed / 11;

  //Serial.println(camera_speed_val);

  if(camera_speed_val > 880)
    camera_speed_val = 880;

  if(camera_speed_val < 198) 
    camera_speed_val = 198;

  int mapped_rotation = (180./682. * camera_speed_val) - (35640./682.) - 90.;
  //Serial.println(mapped_rotation);

  if(mapped_rotation != mapped_camera_rotation && (!(mapped_rotation == 90 && mapped_camera_rotation == -90) || !(mapped_rotation == -90 && mapped_camera_rotation == 90))) {
    mapped_camera_rotation = mapped_rotation;
    Serial.println(ROTATE_CAMERA + "," + mapped_camera_rotation);
  }

}
