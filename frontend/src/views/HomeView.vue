<script setup lang="ts">
import { useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth = useAuthStore()
const router = useRouter()

async function onLogout() {
  await auth.logout()
  await router.push({ name: 'login' })
}
</script>

<template>
  <main class="wrapper">
    <section class="card">
      <h1>Bienvenido, {{ auth.user?.name }}</h1>
      <p>Correo: {{ auth.user?.email }}</p>
      <p>Esta es una ruta protegida: solo se ve con sesión válida.</p>
      <button @click="onLogout">Cerrar sesión</button>
      <small>Kenovit Garcia - Lr-2024-00841</small>
    </section>
  </main>
</template>

<style scoped>
.wrapper { min-height: 100vh; display: grid; place-items: center; }
.card {
  background: #fff; padding: 2rem; border-radius: 12px; max-width: 420px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08); display: grid; gap: 0.8rem;
}
h1 { margin: 0; font-size: 1.4rem; }
p { margin: 0; }
button {
  padding: 0.7rem; border: 0; border-radius: 8px; background: #6366f1;
  color: #fff; cursor: pointer; font-size: 1rem;
}
small { color: #64748b; text-align: center; }
</style>