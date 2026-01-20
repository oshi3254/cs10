#include <iostream>
#include <string>
using namespace std;

enum class Color {
    BLACK, WHITE, GREY, BROWN, DARK_BROWN, BLACK_STRIPES, WHITE_STRIPES
};

enum class Size 
{
    SMALL, MEDIUM, LARGE, HUGE
};

class Animal {
protected:
    Color color;
    Size size;

public:
    Animal(Color c, Size s) : color(c), size(s) {}
    virtual ~Animal() {}

    virtual void sound() = 0;
    virtual void eat() = 0;
};

class Mammalia : public Animal {
protected:
    int numberBabies;

public:
    Mammalia(Color c, Size s, int nb)
        : Animal(c, s), numberBabies(nb) {
    }

    void run() {
        cout << "Mammalia is running" << endl;
    }
};

class Dog : public Mammalia {
protected:
    bool fierce;

    Dog(Color c, Size s, int nb, bool f)
        : Mammalia(c, s, nb), fierce(f) {
    }

public:
    void bark() {
        cout << "Dog bark" << endl;
    }

    void bite() {
        cout << "Dog bite" << endl;
    }

    void sound() override {
        cout << "Dog sound" << endl;
    }

    void eat() override {
        cout << "Dog eating" << endl;
    }
};

class ThaiRidgeBack : public Dog {
private:
    string origin;

public:
    ThaiRidgeBack(Color c, Size s, int nb, bool f, string o)
        : Dog(c, s, nb, f), origin(o) {
    }

    string getOrigin() {
        return origin;
    }
};

class Aves : public Animal {
public:
    Aves(Color c, Size s) : Animal(c, s) {}

    void fly() {
        cout << "Bird is flying" << endl;
    }
};

class Bird : public Aves {
protected:
    string egg;

public:
    Bird(Color c, Size s, string e)
        : Aves(c, s), egg(e) {
    }

    void sound() override {
        cout << "Bird sound" << endl;
    }

    void eat() override {
        cout << "Bird eating" << endl;
    }
};

class HummingBird final : public Bird {
public:
    HummingBird(Color c, Size s, string e)
        : Bird(c, s, e) {
    }
};

class Osteicthyes : public Animal {
public:
    Osteicthyes(Color c, Size s) : Animal(c, s) {}

    void swimming() {
        cout << "Fish is swimming" << endl;
    }

    void sound() override {
        cout << "Fish sound" << endl;
    }

    void eat() override {
        cout << "Fish eating" << endl;
    }
};

class Fish : public Osteicthyes {
protected:
    string waterGroup;

public:
    Fish(Color c, Size s, string wg)
        : Osteicthyes(c, s), waterGroup(wg) {
    }
};

class AngelFish : public Fish {
private:
    string location;

public:
    AngelFish(Color c, Size s, string wg, string loc)
        : Fish(c, s, wg), location(loc) {
    }

    string getLocation() {
        return location;
    }
};

int main()
{
    ThaiRidgeBack dog(Color::BLACK_STRIPES, Size::MEDIUM, 3, true, "Thailland");

    dog.sound();
    dog.eat();
    dog.run();
    dog.bark();
    dog.bite();
    cout << "Origin: " << dog.getOrigin() << endl;

    HummingBird bird(Color::BLACK, Size::LARGE, "Small egg");

    bird.sound();
    bird.eat();
    bird.fly();

    AngelFish fish(Color::BROWN, Size::MEDIUM, "Fresh Water", "Amazon River");

    fish.sound();
    fish.eat();
    fish.swimming();
    cout << "Location: " << fish.getLocation() << endl;

    return 0;
}
