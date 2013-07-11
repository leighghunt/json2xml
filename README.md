json2xml
========

Easy embedding of JSON text into XML config file

Use to encode JSON into an XML file.

E.g.:

The following JSON:

````
[
  {
    "A": 1,
    "B": 2
  }
]
````

Might be encoded into the following XML file:

````
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="Something or other" value ="[{'A':1,'B':2}]"/>
  </appSettings>
</configuration>
````