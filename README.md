# Triviafy

Software destinado al entretenimiento del usuario mediante la adivinación de entre cuatro artistas y una canción por cada uno, la que sea la correcta según el fragmento que suena.

## Comenzando

La aplicación consta de un servicio web, un cliente y al mismo tiempo consume una API externa.

### Instalación

Para la instalación se debe correr el servicio WCF que trata la data de la API conectándose con la aplicación. Este se puede subir a un servidor de aplicaciones. En este caso lo hemos subido a AWS en una instancia de EC2 (Elastic BeansTalk) para que pueda ser accesible desde cualquier parte del mundo.

```
Se debe correr la aplicación Javascript del cliente para poder acceder al juego, la aplicación realiza la conexión con el servicio cuando lo necesita.
```

## Realizar los tests

Si se abre el código en Visual Studio, en la pestaña "Pruebas" escogemos correr todas las pruebas, tnemos pruebas para cada uno de los métodos del servicio y para el que lo desencadena (Trigger).

### Descripción de los tests:

Tenemos dos clases de tests: 
                  1)TriggeringTests.cs
                  2)ClientHttpTriviafyTests.cs
También tenemos una clase llamada TestBase.cs que es básicamente nuestro Container donde utilizamos el boostrapper para aplicar dependence injection. 

La primera contiene un test que responde a la clase que desencadena el resto de métodos dentro del servicio. Prueba el resultado final.

La segunda clase contiene 3 tests y en ella utilizamos una instancia obtenida por el container que obtiene de TestBase.cs para aplicar dependence Injection. Los tests que contiene son: 

```

                                              1)CanGetOAuthAsync: Obtiene token de autorización probando el método del servicio, 
                                              llamado GetOAuthAsync, que al enviar las credenciales del cliente obtiene una autorización                                               de tipo Bearer.
                                              
                                              2)CanGetPlaylist: Prueba el método del servicio que se llama GetPlaylist, mediante el                                                     envío necesario en forma de header del token Bearer de autorización, obtiene una                                                         playlist llamando al método correspondiente de la API de Spotify. 
                                              
                                              3)CanGetAPlaylistTracks: Prueba el método del servicio que se llama GetAPlaylistTracks,                                                   mediante el envío necesario en forma de header del token Bearer de autorización y el ID                                                 de la playlist, obtiene los tracks de una playlist llamando al método correspondiente de                                                 la API de Spotify. 
```


## Componentes

* [API Spotify](https://developer.spotify.com/) - Utilizamos la API de Spotify como fuente de las canciones.
* [Servicio Web](https://github.com/lupitia1/TriviafyWebService) - Servicio web para conectarse a la API y obtener un resultado Json.
* [Spotify Web Playback SDK](https://developer.spotify.com/documentation/web-playback-sdk/) - Componente de Spotify añadido al cliente para reproducir audio.
* [Cliente/Aplicación Javascript](https://github.com/dcolme/Triviafy) - Frontend Javascript donde se lleva a cabo el juego y que consume el servicio web.
* [Instancia EC2 Amazon Web Services](http://triviafywebservice1.us-east-1.elasticbeanstalk.com/TriviafyWebService.svc) - Instancia de Elastic Beanstalk para correr el servicio web.


## Lenguajes utilizados

En este proyecto utilizamos los siguientes lenguajes:
-> C# en el servicio Web
-> Javascript en el cliente

## Authors

* **Patricia Alvarenga**
* **Daniel Comenares**
* **Jose Caldeira** 

## Acknowledgments

* Sergio G. Maroto
