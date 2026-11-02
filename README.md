Directorio de Usuarios - JSONPlaceholderAplicación web desarrollada con TypeScript que consume el endpoint /users de la API pública JSONPlaceholder mediante fetch() y muestra la información de forma dinámica en tarjetas dentro de una página HTML.Flujo de la aplicaciónAPI REST $\rightarrow$ fetch() $\rightarrow$ Respuesta JSON $\rightarrow$ Interfaces TypeScript $\rightarrow$ Procesamiento de datos $\rightarrow$ DOM $\rightarrow$ HTMLTecnologíasTypeScriptHTML5CSS3Estructura del proyectoPlaintextjsonplaceholder-users-app/
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
src/interfaces/user.interface.ts: interfaces User, Address, Geo y Company que describen los datos de la API.src/main.ts: realiza el fetch(), tipa la respuesta como User[] y renderiza las tarjetas en el DOM.dist/: código JavaScript generado por el compilador de TypeScript.Cómo ejecutarloClonar el repositorio:Bashgit clone https://github.com/Kenflowx/jsonplaceholder-users-app.git
cd jsonplaceholder-users-app
Instalar las dependencias:Bashnpm install
Compilar TypeScript:Bashnpm run build
Levantar un servidor local:Bashnpx serve .
Abrir en el navegador la URL que indique (normalmente http://localhost:3000).Se necesita un servidor local porque los módulos ES no funcionan abriendo index.html directamente con doble clic.AutorKenovit Garcia - Lr-2024-00841Proyecto integrador: Login con ASP.NET Core + Vue.jsAutor: Kenovit Garcia - Lr-2024-00841backend/: ASP.NET Core Web API (C#), SQLite, contraseñas con hash BCrypt, JWT guardado en cookie HttpOnly, rutas protegidas con [Authorize].frontend/: Vue.js + TypeScript, Vue Router con guard de autenticación y Pinia.EjecutarBackend: cd backend y dotnet run --no-launch-profile (http://localhost:5000)Frontend: cd frontend, npm install y npm run dev (http://localhost:5173)Usuario de prueba: kenovit@example.com
