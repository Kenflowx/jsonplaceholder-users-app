<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth = useAuthStore()
const router = useRouter()

const email = ref('')
const password = ref('')
const error = ref('')
const loading = ref(false)

async function onSubmit() {
  error.value = ''
  loading.value = true
  try {
    await auth.login(email.value, password.value)
    await router.push({ name: 'home' })
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'Error inesperado'
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <main class="wrapper">
    <form class="card" @submit.prevent="onSubmit">
      <h1>Iniciar sesión</h1>

      <label>
        Correo
        <input v-model="email" type="email" required autocomplete="username" />
      </label>

      <label>
        Contraseña
        <input v-model="password" type="password" required autocomplete="current-password" />
      </label>

      <p v-if="error" class="error">{{ error }}</p>

      <button type="submit" :disabled="loading">
        {{ loading ? 'Entrando...' : 'Entrar' }}
      </button>

      <small>Proyecto integrador - Kenovit Garcia</small>
    </form>
  </main>
</template>

<style scoped>
.wrapper { min-height: 100vh; display: grid; place-items: center; }
.card {
  background: #fff; padding: 2rem; border-radius: 12px; width: 320px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08); display: grid; gap: 1rem;
}
h1 { margin: 0; font-size: 1.4rem; }
label { display: grid; gap: 0.3rem; font-size: 0.9rem; }
input { padding: 0.6rem; border: 1px solid #cbd5e1; border-radius: 8px; }
button {
  padding: 0.7rem; border: 0; border-radius: 8px; background: #6366f1;
  color: #fff; cursor: pointer; font-size: 1rem;
}
button:disabled { opacity: 0.6; cursor: wait; }
.error { color: #dc2626; margin: 0; font-size: 0.9rem; }
small { color: #64748b; text-align: center; }
</style>