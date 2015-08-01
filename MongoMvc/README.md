# MongoMvc

The MongoMvc project is updated version of original content by Shayne Boyer: [Building Web API using MVC 6 & MongoDB](http://tattoocoder.azurewebsites.net/building-vnext-web-api-using-mvc-6-mongodb-azure/) with original source code available on GitHub: [spboyer/MongoMvc](https://github.com/spboyer/mongomvc)

## Changes to original source code

* Code updated to `beta6` version
* NuGet packages updated due to changes in name or in availability
* Code is better structured for learning purposes: `Data` and `Repository` directories are not present in original source code
* The port is based on `generator-aspnet` WebAPI template project, which was not present during original article publication
* One could create `Interface` source code with `generator-aspnet` now
* The MongoDB driver code is updated to version 2.\*:


```csharp
// 1.*
private MongoDatabase Connect()
{
    var client = new MongoClient(_settings.MongoConnection);
    var server = client.GetServer();
    var database = server.GetDatabase(_settings.Database);

    return database;
}
// 2.*
private IMongoDatabase Connect()
{
    var client = new MongoClient(_settings.MongoConnection);
    var database = client.GetDatabase(_settings.Database);
    return database;
}
```
* the settings objects also contains `Collection` key:
* the MongoDB driver was also updated to not use legacy `mongocsharpdriver` (even if updated to 2.0.1):

```json
"mongocsharpdriver": "1.8.3"
```
```json
"MongoDB.Driver": "2.0.1",
"MongoDB.Driver.Core": "2.0.1",
"MongoDB.Bson": "2.0.1"
```
* the POCO objects does not use _BSON_ attributes to map object attributes. Instead updated code uses MongoDB naming conventions for _CamelCase_ mapping:

```csharp
var conventionPack = new ConventionPack();
conventionPack.Add(new CamelCaseElementNameConvention());
ConventionRegistry.Register("CamelCase", conventionPack, t => true);
```
* the repository pattern code is moved to dedicated _Repository_ directory
* the updated _CRUD_ implementation is fully based on MongoDB v.2.* Driver features including filters, expressions and asynchronous execution. Example migration:

```csharp
public void Update(Speaker speaker)
 {
     var query = Query<Speaker>.EQ(e => e.Id, speaker.Id);
     var update = Update<Speaker>.Replace(speaker); // update modifiers
     _database.GetCollection<Speaker>("speakers").Update(query, update);
 }
````

```csharp
public async void Update(Speaker speaker)
{
    var filter = Builders<Speaker>.Filter;
    var query = filter.Where(x => x.Id == speaker.Id);
    var results = await _database.GetCollection<Speaker>(_settings.Collection)
        .ReplaceOneAsync(query, speaker);
}
```
## Instructions

* clone this repository and switch to this project folder
* run `dnu restore`
* run `dnu build`
* run `dnx . kestrel`

If you are using _Visual Studio Code_ just open this directory as project source and you should be able to work with project stright from the editor.
