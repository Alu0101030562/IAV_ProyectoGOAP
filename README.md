# Inteligencia Artificial en Videojuegos - Proyecto GOAP

## Agents

This project has four different agents and each of them has different actions depending on the situation.

### Fast food worker

The goal of the fast food worker is to take the customer's order and go to the stall behind him and give him part of the order.

- **Attending**: Once the customer arrives at the counter he/she takes the customer's order
- **Order**: After taking the order he/she goes to the drinks shelf to get the drinks and give them to the customer.

![](https://github.com/Alu0101030562/IAV_ProyectoGOAP/blob/main/gifs/FastFoodWorker.gif)

### Cook

the cook has the goal to pick up the rest of the order and go to the kitchen to prepare it and give it to the customer, completing his order.

- **Attend Client**: when the customer arrives at the counter he/she takes the order.
- **Go to Kitchen**: Once the order is received, he/she goes to the available kitchen and prepares the food.
- **Deliver Order**: After finishing in the kitchen, returns to the counter and gives the rest of the order to the customer
- **Rest**: in some cases, the cook can go to the rest area if he/she is tired
- **Go to toilet**: in some cases, the cook can go to the staff toilet
- **Burst**: in case the staff toilets are busy and he/she cannot go, he/she will have a burst.

![](https://github.com/Alu0101030562/IAV_ProyectoGOAP/blob/main/gifs/Cook.gif)

### Janitor

the janitor has the goal of clean up the bursts of the customers and cooks who have not been able to get to the toilet in time. He stays in the rest area in case everything is clean.

- **clean puddle**: cleans puddles on the ground
- **rest**: in case there is no puddle, goes to rest.

![](https://github.com/Alu0101030562/IAV_ProyectoGOAP/blob/main/gifs/Janitor.gif)

### Client

The customer aims to go through the entire process of eating at a fast food restaurant.

- **Go To Entrance**: He goes to the entrance of the restaurant
- **GetOrder**: If the counter is free, he goes to place the order and get part of it
- **Go To Waiting**: After placing the order, he goes to wait until the cook is free and can serve him
- **Get Order Complete**: Once he goes to the cook and the cook returns the complete order
- **Go eat**: After receiving the order, go to one of the randomly available tables
- **Go To Bin**: After eating, go to the bin to throw away the leftovers
- **Go Home**: After going to the bin, go home
- **Go To Public Toilet**: In some cases, the customer has to use the available public toilets
- **Burst Public**: In case of not being able to arrive on time because the toilets are busy, they have a burst.

![](https://github.com/Alu0101030562/IAV_ProyectoGOAP/blob/main/gifs/Client.gif)
