from tkinter import *
import time
import numpy

class Car:
    def __init__(self, canvas, colour, topX, topY, bottomX, bottomY, direction, turnDirection):
        self.canvas = canvas
        self.direction = direction
        self.turnDirection = turnDirection
        self.location = self.canvas.create_rectangle(topX, topY, bottomX, bottomY, fill=colour)

    #def turn():
    #    topXOld, topYOld, bottomXOld, bottomYOld = self.canvas.coords(self.location)
    #    self.canvas.coords(topXOld+5, topYOld-10, bottomXOld+10, bottomYOld-5)

    #def getDirectionX(distanceX):
    #    if (self.direction == "left"):
    #        return distanceX * -1
    #    if (self.direction == "right"):
    #        return distanceX

    def move(self, distanceX, distanceY):
        topXOld, topYOld, bottomXOld, bottomYOld = self.canvas.coords(self.location)
        averageX = [topXOld, bottomXOld]
        centre = numpy.mean(averageX)
        x = 0

        if (self.direction == "left"):
            x = distanceX * -1
        if (self.direction == "right"):
            x = distanceX
        if (self.turnDirection == "left"):
            bla = ""
        if (self.direction == "right" and self.turnDirection == "right"):
            if (centre < 215):
                self.canvas.move(self.location, x, distanceY)
            if (centre == 215):
                # Turn
                self.canvas.coords(topXOld+5, topYOld-10, bottomXOld+10, bottomYOld-5)
            if (centre >= 215):
                self.canvas.move(self.location, distanceY, x)
        if (self.direction == "left" and self.turnDirection == "right"):
            if (centre >= 215):
                self.canvas.move(self.location, x, distanceY)
            if (centre == 215):
                # Turn
                self.canvas.coords(topXOld+5, topYOld-10, bottomXOld+10, bottomYOld-5)
            if (centre < 215):
                self.canvas.move(self.location, distanceY, x)
    
class RouteController:
    def __init__(self, canvas):
        self.canvas = canvas
        self.cars = []

    def createCars(self):
        car1 = Car(self.canvas, "red", 0, 125, 30, 145, "right", "right")
        car2 = Car(self.canvas, "blue", 420, 105, 450, 125, "left", "right")
        self.cars.append(car1)
        self.cars.append(car2)
        #car3 = Car("white", "car3", 2, 3)
        #car4 = Car("black", "car4", 5, 5)

    def moveCars(self):
        for i in range(50):
            for car in self.cars:
                car.move(10, 0)
            self.canvas.update()
            time.sleep(0.05)

class Main:    
    # Create window
    root = Tk()
    canvas = Canvas(root, width=450, height=250, bg="grey")
    canvas.pack()
    canvas.create_rectangle(0, 0, 200, 100, fill="green")
    canvas.create_rectangle(0, 150, 200, 250, fill="green")
    canvas.create_rectangle(250, 0, 450, 100, fill="green")
    canvas.create_rectangle(250, 150, 450, 250, fill="green")
        
    # Move cars
    routeController = RouteController(canvas)
    routeController.createCars()
    routeController.moveCars()

    # GO!!
    root.mainloop()