##For model project
Create IEntity and Entity(base class) with T Id value which generated Id field for any derived class

For Auditable entity it will create 4 properties columns

##For repository project

Create Generic repository for resuable code so that PersonRepo and CountryRepo can use Generic repo implement and can write another function

Unit of work class is use for 1 sychornorous save method between class

##For service project
Call from person and country service class to repo class to get id

Country and person service class is derived from entity service class so that we have the CRUD implement and getid function we wrote

##For mvc project
From controller -> services -> repository