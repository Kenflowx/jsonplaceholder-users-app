import { computed, ref } from 'vue'
import { defineStore } from 'pinia'
import { getMe, login as apiLogin, logout as apiLogout, type UserDto } from '@/api/auth'

export const useAuthStore = defineStore('auth', () => {
  const user = ref<UserDto | null>(null)
  const ready = ref(false)
  const isAuthenticated = computed(() => user.value !== null)

  async function loadSession() {
    if (ready.value) return
    try {
      user.value = await getMe()
    } catch {
      user.value = null
    } finally {
      ready.value = true
    }
  }

  async function login(email: string, password: string) {
    user.value = await apiLogin(email, password)
    ready.value = true
  }

  async function logout() {
    await apiLogout()
    user.value = null
  }

  return { user, isAuthenticated, loadSession, login, logout }
})