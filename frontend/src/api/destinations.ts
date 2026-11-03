import { http } from './http'

export interface DestinationDto {
  id: number
  name: string
  country: string
  description: string
  pricePerPerson: number
  durationDays: number
}

export const getDestinations = () => http<DestinationDto[]>('/api/destinations')