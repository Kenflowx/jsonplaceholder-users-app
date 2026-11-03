# Directorio de Usuarios - JSONPlaceholder

AplicaciÃ³n web desarrollada con **TypeScript** que consume el endpoint `/users` de la API pÃºblica [JSONPlaceholder](https://jsonplaceholder.typicode.com/) mediante `fetch()` y muestra la informaciÃ³n de forma dinÃ¡mica en tarjetas dentro de una pÃ¡gina HTML.

## Flujo de la aplicaciÃ³n

API REST -> fetch() -> Respuesta JSON -> Interfaces TypeScript -> Procesamiento de datos -> DOM -> HTML

## TecnologÃ­as

- TypeScript
- HTML5
- CSS3

## Estructura del proyecto

```text
jsonplaceholder-users-app/
â”œâ”€â”€ index.html
â”œâ”€â”€ css/
â”‚   â””â”€â”€ styles.css
â”œâ”€â”€ src/
â”‚   â”œâ”€â”€ interfaces/
â”‚   â”‚   â””â”€â”€ user.interface.ts
â”‚   â””â”€â”€ main.ts
â”œâ”€â”€ dist/            (JavaScript compilado)
â”œâ”€â”€ tsconfig.json
â”œâ”€â”€ package.json
â””â”€â”€ README.md
```

- `src/interfaces/user.interface.ts`: interfaces `User`, `Address`, `Geo` y `Company` que describen los datos de la API.
- `src/main.ts`: realiza el `fetch()`, tipa la respuesta como `User[]` y renderiza las tarjetas en el DOM.
- `dist/`: cÃ³digo JavaScript generado por el compilador de TypeScript.

## CÃ³mo ejecutarlo

1. Clonar el repositorio:
```bash
   git clone https://github.com/Kenflowx/jsonplaceholder-users-app.git
   cd jsonplaceholder-users-app
```
2. Instalar las dependencias:
```bash
   npm install
```
3. Compilar TypeScript:
```bash
   npm run build
```
4. Levantar un servidor local:
```bash
   npx serve .
```
5. Abrir en el navegador la URL que indique (normalmente `http://localhost:3000`).

> Se necesita un servidor local porque los mÃ³dulos ES no funcionan abriendo `index.html` directamente con doble clic.

## Autor

Kenovit Garcia - Lr-2024-00841

---

## Proyecto integrador: Agencia de Viajes (ASP.NET Core + Vue.js)

Autor: Kenovit Garcia - Lr-2024-00841

Aplicación web de una agencia de viajes con login seguro, catálogo de destinos y reservas.

### Tecnologías
- **Backend** (`backend/`): ASP.NET Core Web API (C#), Entity Framework Core con migraciones, PostgreSQL, contraseñas con hash BCrypt, JWT guardado en cookie `HttpOnly` y rutas protegidas con `[Authorize]`.
- **Frontend** (`frontend/`): Vue.js + TypeScript, Vue Router con guard de autenticación y Pinia.
- **Base de datos**: PostgreSQL en un contenedor Docker (`docker-compose.yml`).

### Módulos del backend
- `Modules/Auth`: registro, login, logout y usuario actual.
- `Modules/Destinations`: listado, detalle y creación de destinos.
- `Modules/Reservations`: crear, listar y cancelar reservas del usuario.

### Cómo ejecutarlo
1. Base de datos: `docker compose up -d`
2. Migraciones: `cd backend`, `dotnet tool update --global dotnet-ef`, `dotnet ef database update`
3. Backend: `dotnet run --no-launch-profile` (http://localhost:5000)
4. Frontend: `cd frontend`, `npm install`, `npm run dev` (http://localhost:5173)
5. Usuario de prueba: `kenovit@example.com` / `Admin123*`
