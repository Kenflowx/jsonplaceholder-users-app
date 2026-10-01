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
├── dist/            (JavaScript compilado)
├── tsconfig.json
├── package.json
└── README.md
```

- `src/interfaces/user.interface.ts`: interfaces `User`, `Address`, `Geo` y `Company` que describen los datos de la API.
- `src/main.ts`: realiza el `fetch()`, tipa la respuesta como `User[]` y renderiza las tarjetas en el DOM.
- `dist/`: código JavaScript generado por el compilador de TypeScript.

## Cómo ejecutarlo

1. Clonar el repositorio:
```bash
   git clone https://github.com/TU_USUARIO/jsonplaceholder-users-app.git
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

> Se necesita un servidor local porque los módulos ES no funcionan abriendo `index.html` directamente con doble clic.

## Autor

Kenovit Garcia - Lr-2024-00841