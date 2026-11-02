# Directorio de Usuarios - JSONPlaceholder

Aplicacion web desarrollada con **TypeScript** que consume el endpoint `/users` de la API pubblica [JSONPlaceholder](https://jsonplaceholder.typicode.com/) mediante `fetch()` y muestra la informacionn de forma dinamica en tarjetas dentro de una pagina HTML.

## Flujo de la aplicacion

API REST -> fetch() -> Respuesta JSON -> Interfaces TypeScript -> Procesamiento de datos -> DOM -> HTML

## Tecnologias

- TypeScript
- HTML5
- CSS3

## Estructura del proyecto

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
```

- `src/interfaces/user.interface.ts`: interfaces `User`, `Address`, `Geo` y `Company` que describen los datos de la API.
- `src/main.ts`: realiza el `fetch()`, tipa la respuesta como `User[]` y renderiza las tarjetas en el DOM.
- `dist/`: codigo JavaScript generado por el compilador de TypeScript.

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

## Proyecto integrador: Login con ASP.NET Core + Vue.js

Autor: Kenovit Garcia - Lr-2024-00841

- `backend/`: ASP.NET Core Web API (C#), SQLite, contraseñas con hash BCrypt, JWT guardado en cookie `HttpOnly`, rutas protegidas con `[Authorize]`.
- `frontend/`: Vue.js + TypeScript, Vue Router con guard de autenticación y Pinia.

### Ejecutar
1. Backend: `cd backend` y `dotnet run --no-launch-profile` (http://localhost:5000)
2. Frontend: `cd frontend`, `npm install` y `npm run dev` (http://localhost:5173)
3. Usuario de prueba: `kenovit@example.com` /
