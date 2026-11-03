<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { getDestinations, type DestinationDto } from '@/api/destinations'
import { createReservation } from '@/api/reservations'

const destinations = ref<DestinationDto[]>([])
const loading = ref(true)
const error = ref('')
const message = ref('')
const selectedId = ref<number | null>(null)
const travelers = ref(1)
const travelDate = ref('')
const today = new Date().toISOString().slice(0, 10)
const money = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })

onMounted(async () => {
  try {
    destinations.value = await getDestinations()
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'No se pudieron cargar los destinos'
  } finally {
    loading.value = false
  }
})

function openForm(id: number) {
  selectedId.value = id
  travelers.value = 1
  travelDate.value = ''
  message.value = ''
  error.value = ''
}

async function reserve() {
  if (selectedId.value === null) return
  error.value = ''
  message.value = ''
  try {
    const result = await createReservation({
      destinationId: selectedId.value,
      travelers: travelers.value,
      travelDate: travelDate.value,
    })
    message.value = `¡Reserva exitosa para ${result.destinationName}! Total: ${money.format(result.total)}`
    selectedId.value = null
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'No se pudo crear la reserva'
  }
}
</script>

<template>
  <main class="container">
    <h1>Destinos Kenflow</h1>
    <p v-if="loading" class="muted">Cargando destinos...</p>
    <p v-if="error" class="error">{{ error }}</p>
    <p v-if="message" class="success">{{ message }}</p>
    <section class="grid">
      <article v-for="d in destinations" :key="d.id" class="card">
        <h2>{{ d.name }}</h2>
        <p class="muted">{{ d.country }} - {{ d.durationDays }} días</p>
        <p>{{ d.description }}</p>
        <p><strong>{{ money.format(d.pricePerPerson) }}</strong> por persona</p>
        <button v-if="selectedId !== d.id" class="btn" @click="openForm(d.id)">Reservar</button>
        <form v-else class="reserve-form" @submit.prevent="reserve">
          <label>
            Viajeros
            <input v-model.number="travelers" type="number" min="1" max="20" required />
          </label>
          <label>
            Fecha de viaje
            <input v-model="travelDate" type="date" :min="today" required />
          </label>
          <div class="actions">
            <button class="btn" type="submit">Confirmar</button>
            <button class="btn btn-secondary" type="button" @click="selectedId = null">Cancelar</button>
          </div>
        </form>
      </article>
    </section>
  </main>
</template>

<style scoped>
h2 { margin: 0 0 0.3rem; }
.reserve-form { display: grid; gap: 0.7rem; margin-top: 0.5rem; }
.actions { display: flex; gap: 0.5rem; }
</style>