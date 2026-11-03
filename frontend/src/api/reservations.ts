import { http } from './http'

export interface ReservationDto {
  id: number
  destinationId: number
  destinationName: string
  country: string
  travelers: number
  travelDate: string
  total: number
  createdAt: string
}

export interface CreateReservationDto {
  destinationId: number
  travelers: number
  travelDate: string
}

export const getMyReservations = () => http<ReservationDto[]>('/api/reservations')

export const createReservation = (data: CreateReservationDto) =>
  http<ReservationDto>('/api/reservations', { method: 'POST', body: JSON.stringify(data) })

export const cancelReservation = (id: number) =>
  http<void>(`/api/reservations/${id}`, { method: 'DELETE' })