# PhotoAtomic.Sunricher
C# API for controlling LED devices from Sunricher (SR-2818WiN and SR-1009).

Source code from [https://github.com/magcode/sunricher-wifi-mqtt](https://github.com/magcode/sunricher-wifi-mqtt) is used as reference, thanks to [magcode](https://github.com/magcode).

Also some other reference was taken from [ArXen42/Sunricher.WiFi](https://github.com/ArXen42/Sunricher.Wifi) thanks to [ArXen42](https://github.com/ArXen42)

This is a complete reimplementation in C# .Net Standard 2.0
i've used the message bytes from the projects above as it was too tedious to discover them maually.

##Note to myself:

Also it is possible to deocmpile easyligting APK from the playstore for other hints on how the entire thing works.

with this API you can create multiple remote to surpass the 8 zone limit
each remote in fact can have up to 8 zone to control (this means 8 SR-1009 receiver) but you  can create up to 2^24 (3 bytes) remote,  so a plenty of light to control!

some odd things aree that some commands already includes indication of the zone in the message argument byte but can actually control other zones trough the zone byte... the message design is very quite confusing.

Also consider that some message are broadcast to all the remote ids and zones

in general when you pair a receiver with a remote it will remember the remote id  + the zone id as message mask for message like dim.
other message like On and Off are already zone based but the zone byte is important anyway
a zone byte all to zeroes looks to be broadcast to all the zones for the remote.

on the remote i've created easy shortcut command for on of and dim to the zone which generates the most meaningful command. anyway it is possible to send any command to the Remote.Send method

