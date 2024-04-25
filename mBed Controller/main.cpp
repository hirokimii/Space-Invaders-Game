#include "mbed.h"
#include "rtos.h"
#include  "SongPlayer.h" 
Serial pc(USBTX, USBRX); // tx, rx
AnalogIn x_pos(p15);
AnalogIn y_pos(p16);
DigitalIn pbFire(p8);
DigitalIn pbEasy(p9); 
DigitalIn pbMedium(p10); 
DigitalIn pbHard(p11);
DigitalOut easy(p12);
DigitalOut medium(p13);
DigitalOut hard(p14);

float gameOverF[18]= {466.0, 349.0, 329.0};
float gameOverT[18]= {0.75, .75, .75};

Mutex setLock;
int set = 0;
SongPlayer mySpeaker(p26);

float youWinF[18]= {1046.0, 1174.0, 1318.0, 1396.0};
float youWinT[18]= {0.25, .25, .25, 1.0};
float bulletF[1] = {600.0};
float bulletT[1] = {.07};

void bullet_thread(void const *args) {
    while(1) {
        if (pc.readable()) {
            char a = pc.getc();
            if (a == 'B') {
                mySpeaker.PlaySong(bulletF, bulletT);
            }
            if (a == 'O') {
                setLock.lock();
                set = 0;
                setLock.unlock();
                mySpeaker.PlaySong(gameOverF, gameOverT);
            }
            if (a == 'W') {
                setLock.lock();
                set = 0;
                setLock.unlock();
                mySpeaker.PlaySong(youWinF, youWinT);
            }
        }
    }
}

int main() {
    
    
    pc.baud(9600);
    pc.printf("Hello World!\n");
    pbFire.mode(PullUp);
    pbEasy.mode(PullUp);
    pbMedium.mode(PullUp);
    pbHard.mode(PullUp);
    Thread t1(bullet_thread);
        
    while (1) {

        int shoot = !(int)pbFire;
        int easy1 = !(int)pbEasy;
        int medium1 = !(int)pbMedium;
        int hard1 = !(int)pbHard;
        if (easy1) {
            setLock.lock();
            set = 1;
            setLock.unlock();
        }
        if (medium1) {
            setLock.lock();
            set = 2;
            setLock.unlock();
        }
        if (hard1) {
            setLock.lock();
            set = 3;
            setLock.unlock();
        }
        

        switch (set) {
            case 1: 
                easy = 1;
                break;
            case 2:
                medium = 1;
                break;
            case 3:
                hard = 1;
                break;
            default:
                break;

        }
        pc.printf("X %.2f F %d M %d ", y_pos.read() * 3.3, shoot, set);
        wait(.011);
        //pc.printf("F %d ", pb);

        //pc.printf("3.6");
    }
}