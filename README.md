# AvaloniaPersonalizado

Este repositorio contiene una aplicación de escritorio creada con [AvaloniaUI](https://avaloniaui.net/) que demuestra cómo combinar FluentAvalonia, CommunityToolkit.MVVM y un enrutador sencillo para gestionar la navegación entre vistas.

## Características principales

- **Patrón MVVM completo**: Los `ViewModel` utilizan `ObservableProperty` de CommunityToolkit.MVVM para exponer propiedades notificables.
- **Navegación declarativa**: Se integra `HistoryRouter` de `Sandreas.Avalonia.SimpleRouter` para cambiar entre vistas desde los `ViewModel` sin acoplarse a la capa de presentación.
- **Interfaz Fluent**: La ventana principal usa `NavigationView` de FluentAvalonia para ofrecer una experiencia moderna con iconografía integrada.
- **Inyección de dependencias**: Los `ViewModel` se registran en un contenedor de servicios de `Microsoft.Extensions.DependencyInjection`, facilitando pruebas y escalabilidad.

## Requisitos previos

- .NET SDK 8.0 o superior
- Un entorno compatible con Avalonia (Windows, Linux o macOS)

## Estructura del proyecto

```text
AvaloniaPersonalizado/
├── App.axaml y App.axaml.cs        # Configuración general de la aplicación e IoC
├── Program.cs                      # Punto de entrada para iniciar Avalonia
├── ViewModels/                     # Capa de ViewModels (Inicio, Configuración y principal)
├── Views/                          # Definiciones XAML y code-behind de las vistas
├── Assets/                         # Recursos de la interfaz (iconos, estilos)
└── app.manifest                    # Manifest para la aplicación de escritorio
```

## Cómo ejecutar el proyecto

1. Restaurar dependencias y compilar:
   ```bash
   dotnet build
   ```
2. Ejecutar la aplicación en modo escritorio:
   ```bash
   dotnet run --project AvaloniaPersonalizado
   ```

## Navegación y flujo

- Al iniciar, la aplicación crea el contenedor de servicios e inicializa el `HistoryRouter` global en `App.axaml.cs`.
- `MainWindowViewModel` se suscribe al router y actualiza `CurrentView` cuando cambia la vista activa.
- El `NavigationView` de la ventana principal vincula `SelectedItem` a `SelectedItem` del `ViewModel`. Cuando el usuario selecciona "Inicio" o "Configuración", se invoca `NavigateTo<TViewModel>()` y el router resuelve el `ViewModel` correspondiente.

## Personalización

- Agrega nuevas vistas creando un `ViewModel` que herede de `ViewModelBase` y registrándolo en `ConfigureServices()`.
- Define la vista XAML dentro de `Views/` y enlázala al `ViewModel` usando `DataTemplates` o la configuración del router.
- Extiende el `NavigationView` añadiendo nuevos `NavigationViewItem` con su texto e icono.

## Licencia

Este proyecto se proporciona tal cual. Ajusta la licencia según las necesidades de tu organización antes de distribuir el software.
