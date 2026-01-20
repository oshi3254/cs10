from enum import Enum
from abc import ABC, abstractmethod
from typing import Final

class Color(Enum):
    BLACK = 1
    WHITE = 2
    GREY = 3
    BROWN = 4
    DARK_BROWN = 5
    BLACK_STRIPES = 6
    WHITE_STRIPES = 7

class Size(Enum):
    SMALL = "SMALL"
    MEDIUM = "MEDIUM"
    LARGE = "LARGE"
    HUGE = "HUGE"

class Animal(ABC):
    def __init__(self, color: Color, size: Size):
        self.color = color
        self.size = size

    @abstractmethod
    def sound(self):
        pass

    @abstractmethod
    def eat(self):
        pass

class Mammalia(Animal):
    def __init__(self, color: Color, size: Size, number_babies: int):
        super().__init__(color, size)
        self.number_babies = number_babies

    def run(self):
        print("Mammalia is running")

class Dog(Mammalia):
    allowed_subclasses = ["ThaiRidgeBack"]

    def __init_subclass__(cls, **kwargs):
        if cls.__name__ not in Dog.allowed_subclasses:
            raise TypeError("Dog is sealed")
        super().__init_subclass__(**kwargs)

    def __init__(self, color, size, number_babies, fierce):
        super().__init__(color, size, number_babies)
        self.fierce = fierce

    def bark(self):
        print("Dog bark")

    def bite(self):
        print("Dog bite")

    def sound(self):
        print("Dog sound")

    def eat(self):
        print("Dog eating")

class ThaiRidgeBack(Dog):
    def __init__(self, color, size, number_babies, fierce, origin):
        super().__init__(color, size, number_babies, fierce)
        self.origin = origin

class Aves(Animal):
    def fly(self):
        print("Bird is flying")

class Bird(Aves):
    def __init__(self, color, size, egg):
        super().__init__(color, size)
        self.egg = egg

    def sound(self):
        print("Bird sound")

    def eat(self):
        print("Bird eating")

class HummingBird(Bird):
    def __init_subclass__(cls, **kwargs):
        raise TypeError("HummingBird is final")

    def __init__(self, color, size, egg):
        super().__init__(color, size, egg)

class Osteicthyes(Animal):
    def swimming(self):
        print("Fish is swimming")

class Fish(Osteicthyes):
    def __init__(self, color, size, waterGroup):
        super().__init__(color, size)
        self.waterGroup = waterGroup

    def sound(self):
        print("Fish sound")

    def eat(self):
        print("Fish eating")

class AngelFish(Fish):
    def __init__(self, color, size, waterGroup, location):
        super().__init__(color, size, waterGroup)
        self.location = location

####################################################################
dog = ThaiRidgeBack(Color.DARK_BROWN, Size.MEDIUM, 3, True, "Thailand")
dog.sound()
dog.eat()
dog.run()
dog.bark()
dog.bite()
print("Origin:", dog.origin)

print("#################################")

bird = HummingBird(Color.WHITE, Size.LARGE, "Small egg")
bird.sound()
bird.eat()
bird.fly()

print("#################################")

fish = AngelFish(Color.WHITE_STRIPES, Size.SMALL, "Fresh water", "Amazon River")
fish.sound()
fish.eat()
fish.swimming()
print("Location:", fish.location)
