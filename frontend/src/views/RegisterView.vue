<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink, useRouter } from 'vue-router'
import { register } from '@/api/auth'

const router = useRouter()
const name = ref('')
const email = ref('')
const password = ref('')
const error = ref('')
const loading = ref(false)

async function onSubmit() {
  error.value = ''
  loading.value = true
  try {
    await register(name.value, email.value, password.value)
    await router.push({ name: 'login', query: { registered: '1' } })
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
      <h1>Kenflow - Registro</h1>
      <label>
        Nombre
        <input v-model="name" type="text" required minlength="2" />
      </label>
      <label>
        Correo
        <input v-model="email" type="email" required autocomplete="username" />
      </label>
      <label>
        Contraseña (mínimo 8 caracteres)
        <input v-model="password" type="password" required minlength="8" autocomplete="new-password" />
      </label>
      <p v-if="error" class="error">{{ error }}</p>
      <button class="btn" type="submit" :disabled="loading">
        {{ loading ? 'Registrando...' : 'Crear cuenta' }}
      </button>
      <small class="muted">¿Ya tienes cuenta? <RouterLink to="/login">Inicia sesión</RouterLink></small>
    </form>
  </main>
</template>