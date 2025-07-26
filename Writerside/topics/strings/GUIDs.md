# GUIDs

GUIDs (**G**lobal **U**nique **ID**entificator)  são identificadores únicos dentro do C#

É um 128-bit integer (16 bytes)

```c#
var id = Guid.NewGuid();
// O retrona será algo assim: 
// → 044e69f7-fe93-4e98-ae0d-f650b37f31ff
System.Console.WriteLine("" + id);
```
