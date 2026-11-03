<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink, useRoute, useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const auth = useAuthStore()
const router = useRouter()
const route = useRoute()

const email = ref('')
const password = ref('')
const error = ref('')
const loading = ref(false)

async function onSubmit() {
  error.value = ''
  loading.value = true
  try {
    await auth.login(email.value, password.value)
    await router.push({ name: 'destinations' })
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'Error inesperado'
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <main class="wrapper">
    <form class="card form-card" @submit.prevent="onSubmit">
      <h1>Iniciar sesión</h1>

      <p v-if="route.query.registered" class="success">Cuenta creada. Ya puedes iniciar sesión.</p>

      <label>
        Correo
        <input v-model="email" type="email" required autocomplete="username" />
      </label>

      <label>
        Contraseña
        <input v-model="password" type="password" required autocomplete="current-password" />
      </label>

      <p v-if="error" class="error">{{ error }}</p>

      <button class="btn" type="submit" :disabled="loading">
        {{ loading ? 'Entrando...' : 'Entrar' }}
      </button>

      <small class="muted">¿No tienes cuenta? <RouterLink to="/register">Regístrate</RouterLink></small>
    </form>
  </main>
</template>