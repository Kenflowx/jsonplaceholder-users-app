<script setup lang="ts">
import { RouterLink, RouterView, useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth = useAuthStore()
const router = useRouter()

async function onLogout() {
  await auth.logout()
  await router.push({ name: 'login' })
}
</script>

<template>
  <header v-if="auth.isAuthenticated" class="nav">
    <strong>Agencia de Viajes</strong>
    <nav>
      <RouterLink to="/">Destinos</RouterLink>
      <RouterLink to="/reservations">Mis reservas</RouterLink>
    </nav>
    <span class="muted">{{ auth.user?.name }}</span>
    <button class="btn btn-secondary" @click="onLogout">Salir</button>
  </header>

  <RouterView />

  <footer class="footer">Proyecto integrador - Kenovit Garcia - Lr-2024-00841</footer>
</template>

<style scoped>
.nav {
  display: flex; align-items: center; gap: 1.2rem; padding: 0.8rem 1.5rem;
  background: #fff; box-shadow: 0 1px 4px rgba(0, 0, 0, 0.08);
}
.nav nav { display: flex; gap: 1rem; flex: 1; }
.nav a { color: #0ea5e9; text-decoration: none; }
.nav a.router-link-exact-active { font-weight: bold; }
.footer { text-align: center; padding: 1.5rem; color: #64748b; font-size: 0.85rem; }
</style>