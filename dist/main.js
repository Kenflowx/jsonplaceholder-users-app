const API_URL = "https://jsonplaceholder.typicode.com/users";
// 1. fetch + tipado de la respuesta JSON
async function obtenerUsuarios() {
    const response = await fetch(API_URL);
    if (!response.ok) {
        throw new Error(`Error HTTP: ${response.status}`);
    }
    const usuarios = await response.json();
    return usuarios;
}
// 2. Procesamiento: convertir un User en una tarjeta HTML
function crearTarjeta(usuario) {
    const tarjeta = document.createElement("article");
    tarjeta.className = "card";
    tarjeta.innerHTML = `
    <h2>${usuario.name}</h2>
    <p class="username">@${usuario.username}</p>
    <ul>
      <li><strong>Email:</strong> ${usuario.email}</li>
      <li><strong>Teléfono:</strong> ${usuario.phone}</li>
      <li><strong>Web:</strong> ${usuario.website}</li>
      <li><strong>Ciudad:</strong> ${usuario.address.city}</li>
      <li><strong>Empresa:</strong> ${usuario.company.name}</li>
    </ul>
  `;
    return tarjeta;
}
// 3. Renderizar en el DOM
function renderizarUsuarios(usuarios) {
    const contenedor = document.getElementById("users-container");
    if (!contenedor)
        return;
    contenedor.innerHTML = "";
    usuarios.forEach((usuario) => {
        contenedor.appendChild(crearTarjeta(usuario));
    });
}
// 4. Punto de entrada
async function iniciar() {
    const estado = document.getElementById("status");
    try {
        const usuarios = await obtenerUsuarios();
        if (estado)
            estado.textContent = `${usuarios.length} usuarios cargados`;
        renderizarUsuarios(usuarios);
    }
    catch (error) {
        if (estado)
            estado.textContent = "No se pudieron cargar los datos.";
        console.error(error);
    }
}
iniciar();
export {};
