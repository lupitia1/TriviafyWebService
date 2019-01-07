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


### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Patricia Alvarenga**
* **Daniel Comenares**
* **Jose Caldeira** 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
