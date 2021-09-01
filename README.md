# __Statusbits__

## Table of Contents
1. [About the Project](#About-the-Project)
2. [Funktion](#Funktion)
3. [Aufbau](#Aufbau)
4. [Problem](#Problem)


## __About the Project__

Das ursprüngliche Programm wurde in "Lua" geschrieben. Um ein besser wartbares System zu haben wurde das Programm in "C#" übersetzt. Es dient dazu von einem Dezimal-, Hexadezimal- oder Binärwert die gesetzten Bits abzufragen und so den Status besser dargestellt zu bekommen.


<img src="./Assets/ReadMe_overview.PNG"/>


## __Funktion__

In dem "Scan From Clipboard" Auswahlfeld kann zwischen den Optionen "no", "hexadecimal", "decimal" und "binary" ausgewählt werden. Über die zwei Buttons neben dem Auswahlfeld können die Bits umgestellt werden. 

Wenn "no" ausgewählt wurde wird keine Eingabe von der Zwischenablage übernommen. Bei allen anderen Optionen wird immer, wenn die Zwischenablage aktualisiert wird, diese mit dem ausgewählten Zahlensystem kopiert und es werden alle anderen Werte berechnet.

Es können auch die Bits mit Klicks auf die Checkboxen ausgewählt werden. 
Beim Eingeben einer Zahl in die Textboxen werden automatisch alle anderen berechnet.

Bei einer falschen Eingabe (Wert ist zu groß, ungültige Zeichen) wird der Fehler in roter Schrift am unteren Rand angezeigt.
<br/>


## __Aufbau__

Das Programm basiert auf einer Model-View-Presenter (MVP) architektur. "MainPage.xaml.cs" kann dabei als "View" angesehen werden, "StatusbitsController.cs" als "Presenter" und "StatusbitsModel.cs" als "Model".
Die Klasse "BitDecryption.cs" dient als Library um die Werte in alle Zahlensysteme umzurechnen und die Klasse HotkeyWindow dient als Subservice, welcher die Änderungen des Clipboards übergibt da Statusbits als UWP app nicht aus dem Hintergrund darauf zugreifen kann. 

__Klassen__
+ StatusbitsController.cs
+ StatusbitsModel.cs
+ BitDecryption.cs
+ HotkeyWindow.cs
+ MainPage.xaml.cs

*__StatusbitsController.cs__*

Über den Controller werden alle Prozesse gemäß den Eingaben, die vom Benutzer getätigt und über die View weitergegeben wurden, aufgerufen.

*__StatusbitsModel.cs__*

In der "StatusbitsModel.cs" Klasse werden alle Variablen gespeichert und bereitgestellt.

*__BitDecryption.cs__*

"BitDecryption.cs" wird als Library zum Berechnen von Dezimal-, Hexadezimal-, und Binärzahlen und der ausgewählten Checkboxen verwendet.

*__HotkeyWindow.cs__*

"HotkeyWindow.cs" wird als Subservice zum Anliefern der Clipboardänderungen verwendet.

*__MainPage.xaml.cs__*

Diese Klasse funktioniert wie eine "View-Klasse" in einem MVP System. Die Klasse wird benutzt um die Eingaben des Benutzers an den Controller weiterzuleiten.
