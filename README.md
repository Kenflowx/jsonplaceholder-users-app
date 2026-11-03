# Directorio de Usuarios - JSONPlaceholder

Aplicación web desarrollada con **TypeScript** que consume el endpoint `/users` de la API pública [JSONPlaceholder](https://jsonplaceholder.typicode.com/) mediante `fetch()` y muestra la información de forma dinámica en tarjetas dentro de una página HTML.

## Flujo de la aplicación

API REST -> fetch() -> Respuesta JSON -> Interfaces TypeScript -> Procesamiento de datos -> DOM -> HTML

## Tecnologías

- TypeScript
- HTML5
- CSS3

## Estructura del proyecto

```text
jsonplaceholder-users-app/
├── index.html
├── css/
│   └── styles.css
├── src/
│   ├── interfaces/
│   │   └── user.interface.ts
│   └── main.ts
├── dist/           (JavaScript compilado)
├── tsconfig.json
├── package.json
└── README.md
src/interfaces/user.interface.ts: interfaces User, Address, Geo y Company que describen los datos de la API.

src/main.ts: realiza el fetch(), tipa la respuesta como User[] y renderiza las tarjetas en el DOM.

dist/: código JavaScript generado por el compilador de TypeScript.

Cómo ejecutarlo
Clonar el repositorio:

Bash
   git clone [https://github.com/Kenflowx/jsonplaceholder-users-app.git](https://github.com/Kenflowx/jsonplaceholder-users-app.git)
   cd jsonplaceholder-users-app
Instalar las dependencias:

Bash
   npm install
Compilar TypeScript:

Bash
   npm run build
Levantar un servidor local:

Bash
   npx serve .
Abrir en el navegador la URL que indique (normalmente http://localhost:3000).

Se necesita un servidor local porque los módulos ES no funcionan abriendo index.html directamente con doble clic.

Autor
Kenovit Garcia - Lr-2024-00841

Proyecto integrador: Agencia de Viajes (ASP.NET Core + Vue.js)
Autor: Kenovit Garcia - Lr-2024-00841

Aplicación web de una agencia de viajes con login seguro, catálogo de destinos y reservas.

Tecnologías
Backend (backend/): ASP.NET Core Web API (C#), Entity Framework Core con migraciones, PostgreSQL, contraseñas con hash BCrypt, JWT guardado en cookie HttpOnly y rutas protegidas con [Authorize].

Frontend (frontend/): Vue.js + TypeScript, Vue Router con guard de autenticación y Pinia.

Base de datos: PostgreSQL en un contenedor Docker (docker-compose.yml).

Módulos del backend
Modules/Auth: registro, login, logout y usuario actual.

Modules/Destinations: listado, detalle y creación de destinos.

Modules/Reservations: crear, listar y cancelar reservas del usuario.

Cómo ejecutarlo
Base de datos: docker compose up -d

Migraciones: cd backend, dotnet tool update --global dotnet-ef, dotnet ef database update

Backend: dotnet run --no-launch-profile (http://localhost:5000)

Frontend: cd frontend, npm install, npm run dev (http://localhost:5173)

Usuario de prueba: kenovit@example.com / Admin123*
