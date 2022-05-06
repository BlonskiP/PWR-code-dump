//
// Created by wilk on 07.06.19.
//

#include <iostream>
#include "Creature.h"
#include "ConsoleManager.h"

using namespace std;

int Creature::getHunger() {
    std::unique_lock<std::mutex> lck(statsAcces);
    return this->hunger;
}

int Creature::getEnergy() {
    std::unique_lock<std::mutex> lck(statsAcces);
    return this->energy;
}

void Creature::changeHungerBy(int change) {
    if(isAlive) {
        std::unique_lock<std::mutex> lck(statsAcces);
        this->hunger += change;
        if (hunger > maxHunger)hunger = maxHunger;
    }
}

void Creature::changeEnergyBy(int change) {
    if(isAlive) {
        std::unique_lock<std::mutex> lck(statsAcces);
        this->energy += change;
        if (energy > maxEnergy)energy = maxEnergy;
    }
}

bool Creature::CheckIfIsAlive() {
    std::unique_lock<std::mutex> lck(statsAcces);
    if(this->energy<0 || this->hunger<0 ) {
        isAlive = false;
    }

    return isAlive;
}

Creature::Creature(string name, char symbol) {

    isAlive=true;
    this->name=name;
    this->symbol=symbol;
    hunger=50;
    energy=50;
    x=25;
    y=10;
    Room *& newRoom=ConsoleManager::roomList[0];
    setRoom(newRoom);


}

void Creature::Survive() {
    while(isAlive && ConsoleManager::survivalIsActive){
        for(int i=0;i<ConsoleManager::roomList.size();i++){
            ConsoleManager::roomList[i]->Use(this);
}
    }
}

Room * Creature::getRoom() {
    return this->room;
}

void Creature::setRoom(Room * room) {
    this->room = room;
}

int Creature::getProgress() {
    std::unique_lock<std::mutex> lck(statsAcces);
    return progress;
}

void Creature::setProgress(int prog) {
    std::unique_lock<std::mutex> lck(statsAcces);
    progress=prog;
}

void Creature::beginSurvival() {
    creatureThread=thread(&Creature::Survive,this);
}


