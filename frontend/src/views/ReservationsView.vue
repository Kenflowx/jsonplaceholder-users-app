<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { cancelReservation, getMyReservations, type ReservationDto } from '@/api/reservations'

const reservations = ref<ReservationDto[]>([])
const loading = ref(true)
const error = ref('')
const money = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })

onMounted(async () => {
  try {
    reservations.value = await getMyReservations()
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'No se pudieron cargar las reservas'
  } finally {
    loading.value = false
  }
})

async function cancel(id: number) {
  error.value = ''
  try {
    await cancelReservation(id)
    reservations.value = reservations.value.filter((r) => r.id !== id)
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'No se pudo cancelar la reserva'
  }
}
</script>

<template>
  <main class="container">
    <h1>Mis Reservas en Kenflow</h1>
    <p v-if="loading" class="muted">Cargando reservas...</p>
    <p v-if="error" class="error">{{ error }}</p>
    <p v-if="!loading && reservations.length === 0" class="muted">Aún no tienes reservas registradas.</p>
    <section class="grid">
      <article v-for="r in reservations" :key="r.id" class="card">
        <h2>{{ r.destinationName }}</h2>
        <p class="muted">{{ r.country }}</p>
        <p>Fecha de viaje: <strong>{{ r.travelDate }}</strong></p>
        <p>Viajeros: {{ r.travelers }}</p>
        <p>Total: <strong>{{ money.format(r.total) }}</strong></p>
        <button class="btn btn-danger" @click="cancel(r.id)">Cancelar reserva</button>
      </article>
    </section>
  </main>
</template>

<style scoped>
h2 { margin: 0 0 0.3rem; }
</style>