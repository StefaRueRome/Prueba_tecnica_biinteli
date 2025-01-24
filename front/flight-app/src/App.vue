<template>
  <div class="min-h-screen bg-gradient-to-br from-indigo-100 via-purple-100 to-pink-100 flex items-center justify-center p-4">
    <div class="bg-white shadow-2xl rounded-2xl border-4 border-purple-200 p-8 w-full max-w-md transform transition-all hover:scale-105 duration-300">
      <div class="flex items-center justify-center mb-6">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-12 w-12 text-purple-600 mr-3" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
        </svg>
        <h1 class="text-4xl font-extrabold text-transparent bg-clip-text bg-gradient-to-r from-purple-600 to-pink-600">
          Viaje por Colombia
        </h1>
      </div>
      <div class="bg-purple-50 p-1 rounded-xl mb-4">
        <RouteSearch @find-route="searchRoute" />
      </div>
      <RouteResults 
        v-if="routeData" 
        :route-data="routeData" 
        :loading="loading"
        class="animate-fade-in"
      />
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import RouteSearch from './components/RouteSearch.vue'
import RouteResults from './components/RouteResults.vue'

export default {
  components: { RouteSearch, RouteResults },
  data() {
    return {
      routeData: null,
      loading: false
    }
  },
  methods: {
    async searchRoute(origin, destination) {
      this.loading = true
      this.routeData = null

      try {
        const response = await axios.get(`http://localhost:7665/api/flights`, {
          params: { origin, destination }
        })
        
        this.routeData = response.data
      } catch (error) {
        console.error('Route Search Error:', error)
        alert('No se pudo encontrar la ruta. Intente de nuevo.')
      } finally {
        this.loading = false
      }
    }
  }
}
</script>

<style>
.animate-fade-in {
  animation: fadeIn 0.5s ease-out;
}

@keyframes fadeIn {
  from { opacity: 0; transform: translateY(-10px); }
  to { opacity: 1; transform: translateY(0); }
}
</style>