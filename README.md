# Related Values
related values is an AI nuget package written in c# and based on Microsoft *Language Undrestanding Intelligent Service* **(LUIS)**

## 2 steps to use Related Values

- Initialization
- Understanding and using the methods

### Initialization

In order to use Related values you need **PhraseList Id**, this operation is just **onetime**
```csharp
LuisParams luisParams = new LuisParams
    {
        AppId = "<App Key>",
        VersionId = "<App version e.g 0.1>",
        SubsKey = "<Luis Primary key>",
        Endpoint = Region.WestEurope
        //Other regions are available in the enum but It's linked to your AppId
        //You will be unauthorized to use the service by choosing a wrong region.
    };
    
ILuis luis = new Luis(luisParams);
/*
This step is one Time only to get a phaselist ID in order to use it as param for 
the RelatedValuesAsync method
In case of lost of the phaseListID you can use the overrided method of 
CreatePhaseListAsync by passing a name for your phaselist.
exmaple CreatePhaseListAsync("phaseListTest")
*/
int phaseListID = await luis.CreatePhaseListAsync();
Console.WriteLine(phaseListID);
```
### Understanding and using the methods
Ones you have the **PhraseList Id** you can change the _luisParams_ object to use the **PhraseListId**.
```csharp
LuisParams luisParams = new LuisParams
    {
        AppId = "<App Key>",
        VersionId = "<App version e.g 0.1>",
        SubsKey = "<Luis Primary key>",
        //this is only used when you have already the ID
        PhraseListId = "<Luis PhaseList ID>",
        Endpoint = Region.WestEurope
    };
 ILuis luis = new Luis(luisParams);  
```
#### Related values method
**Related values** is the core of the *nuget package*. We use the **luis** object that we created before.
The method returns a list of words related to the original list that was passed to it.
The number of the values to return should be also specified in the properties of the method.
```csharp
List<string> response = await luis.RelatedValuesAsync(keywords, number);
```

#### Related values method
**Strong values** is an extension of the *related values*. We use the **luis** object that we created before.
The method returns a list of words **strongly** related to the original list that was passed to it.
The maximum number of the **strong values** to return should be also specified in the properties of the method, the method will return less values that the maximum number.
```csharp
List<string> response = await luis.StrongValuesAsync(keywords, maximum);
```
