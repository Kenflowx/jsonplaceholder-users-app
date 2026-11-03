import { http } from './http'

export interface UserDto {
  id: number
  name: string
  email: string
}

export const register = (name: string, email: string, password: string) =>
  http<UserDto>('/api/auth/register', {
    method: 'POST',
    body: JSON.stringify({ name, email, password }),
  })

export const login = (email: string, password: string) =>
  http<UserDto>('/api/auth/login', {
    method: 'POST',
    body: JSON.stringify({ email, password }),
  })

export const logout = () => http<void>('/api/auth/logout', { method: 'POST' })

export const getMe = () => http<UserDto>('/api/auth/me')