export interface UserDto {
  id: number
  name: string
  email: string
}

async function request<T>(url: string, options: RequestInit = {}): Promise<T> {
  const response = await fetch(url, {
    credentials: 'include', // envía y recibe la cookie HttpOnly
    headers: { 'Content-Type': 'application/json' },
    ...options,
  })

  if (!response.ok) {
    const body = await response.json().catch(() => null)
    throw new Error(body?.message ?? `Error ${response.status}`)
  }

  return response.status === 204 ? (undefined as T) : response.json()
}

export const login = (email: string, password: string) =>
  request<UserDto>('/api/auth/login', {
    method: 'POST',
    body: JSON.stringify({ email, password }),
  })

export const logout = () => request<void>('/api/auth/logout', { method: 'POST' })

export const getMe = () => request<UserDto>('/api/auth/me')