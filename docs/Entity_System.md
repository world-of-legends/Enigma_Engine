# Entity System in Enigma Engine
This system looks like Source Entity System. In Editor you have figures and entities.
## Figures
**Figure** - is a just geometric figure without any information (like Brush in Source).
## Entities
**Entity** - is a object with information (like Entity in Source). It can be model, particles, trigger or other. Has three types of entities:
- Logical - is a entity which invisible in the game. It used for give some information to the game ot other entities.
- Model - is a entity which have model in the game. It can be static model, animating model, door with model and other.
- Figure - is a entity created from Figure. More often this type of entity using for creating triggers.
The main difference between Figure and Entity is that the Entity has a script.
# Event-Action System in Enigma Engine
This system looks like Source I/O System. But what is Event-Action System. Sometimes game or entities execute some **events**. For example: button pressed - it is event. Or game finished - it is event too. And other entities want to react on these events. For example: door open, when button pressed. These reactions named **actions**. And all this system of events and actions is *Event-Action System*. Every entity have own events and actions.
