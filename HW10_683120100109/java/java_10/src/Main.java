enum Color {
    BLACK, WHITE, GREY, BROWN, DARK_BROWN, BLACK_STRIPES, WHITE_STRIPES
}

enum Size {
    SMALL, MEDIUM, LARGE, HUGE

}

abstract class Animal {
    protected Color color;
    protected  Size size;

    public  Animal(Color color, Size size) {
        this.color = color;
        this.size = size;
    }

    public  abstract void  sound();
    public  abstract  void  eat();
}

abstract class Mammalia extends Animal {
    protected int numberBabies;

    public Mammalia(Color color, Size size, int numberBabies) {
        super(color, size);
        this.numberBabies = numberBabies;
    }

    public void run() {
        System.out.println("Mammalia is running");
    }
}

sealed class Dog extends Mammalia
        permits ThaiRidgeBack {

    protected boolean fierce;

    public Dog(Color color, Size size, int numberBabies, boolean fierce) {
        super(color, size, numberBabies);
        this.fierce = fierce;
    }

    public void bark() {
        System.out.println("Dog bark");
    }

    public void bite() {
        System.out.println("Dog bite");
    }

    @Override
    public void sound() {
        System.out.println("Dog sound");
    }

    @Override
    public void eat() {
        System.out.println("Dog eating");
    }
}

final class ThaiRidgeBack extends Dog {
    private String origin;

    public ThaiRidgeBack(Color color, Size size, int numberBabies,
                         boolean fierce, String origin) {
        super(color, size, numberBabies, fierce);
        this.origin = origin;
    }

    public String getOrigin() {
        return origin;
    }
}

abstract class Aves extends Animal {

    public Aves(Color color, Size size) {
        super(color, size);
    }

    public void fly() {
        System.out.println("Bird is flying");
    }

    @Override
    public void sound() {
        System.out.println("Aves sound");
    }

    @Override
    public void eat() {
        System.out.println("Aves eating");
    }
}

class Bird extends Aves {
    protected String egg;

    public Bird(Color color, Size size, String egg) {
        super(color, size);
        this.egg = egg;
    }
}

final class HummingBird extends Bird {

    public HummingBird(Color color, Size size, String egg) {
        super(color, size, egg);
    }
}

abstract class Osteichthyes extends Animal {

    public Osteichthyes(Color color, Size size) {
        super(color, size);
    }

    public void swimming() {
        System.out.println("Fish is swimming");
    }

    @Override
    public void sound() {
        System.out.println("Fish sound");
    }

    @Override
    public void eat() {
        System.out.println("Fish eating");
    }
}

class Fish extends Osteichthyes {
    protected String waterGroup;

    public Fish(Color color, Size size, String waterGroup) {
        super(color, size);
        this.waterGroup = waterGroup;
    }
}

class AngelFish extends Fish {
    private String location;

    public AngelFish(Color color, Size size,
                     String waterGroup, String location) {
        super(color, size, waterGroup);
        this.location = location;
    }

    public String getLocation() {
        return location;
    }
}


void main() {
    ThaiRidgeBack dog = new ThaiRidgeBack(Color.BLACK_STRIPES, Size.LARGE, 4, true, "Thailand");
    dog.sound();
    dog.eat();
    dog.run();
    dog.bark();
    dog.bite();
    System.out.println("Origin: " + dog.getOrigin());

    System.out.println("--------------------");

    HummingBird bird = new HummingBird(Color.GREY, Size.SMALL, "Small egg");
    bird.sound();
    bird.eat();
    bird.fly();

    System.out.println("--------------------");

    AngelFish fish = new AngelFish(Color.GREY, Size.LARGE, "Fresh Water", "Amazon River");
    fish.sound();
    fish.eat();
    fish.swimming();
    System.out.println("Location: " + fish.getLocation());
}
