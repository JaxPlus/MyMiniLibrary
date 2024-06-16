<script setup lang="ts">
import {onMounted, ref} from "vue";
import Stats from "../Models/Stats";

const isMenuExpanded = ref(false);
const stats = ref<Stats>();

async function getStats() {
  stats.value = await fetch("http://localhost:5296/stats")
      .then((res) => res.json())
      .catch((error) => console.error(error));
}

onMounted(async () => {
  await getStats();
})
</script>

<template>
  <div class="menu">
    <button @click="isMenuExpanded = true" class="menu-btn-open menu-btn">
      <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24"><g fill="none" stroke="#535bf2" stroke-width="1.5"><circle cx="5" cy="12" r="2"/><circle cx="12" cy="12" r="2" opacity="0.5"/><circle cx="19" cy="12" r="2"/></g></svg>
    </button>
    <div v-if="isMenuExpanded" class="expanded-menu">
      <button @click="isMenuExpanded = false" class="menu-btn-close menu-btn">
        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24"><g stroke="#535bf2" stroke-linecap="round" stroke-width="2"><path fill="#535bf2" fill-opacity="0" stroke-dasharray="60" stroke-dashoffset="60" d="M12 3C16.9706 3 21 7.02944 21 12C21 16.9706 16.9706 21 12 21C7.02944 21 3 16.9706 3 12C3 7.02944 7.02944 3 12 3Z"><animate fill="freeze" attributeName="stroke-dashoffset" dur="0.5s" values="60;0"/><animate fill="freeze" attributeName="fill-opacity" begin="0.8s" dur="0.15s" values="0;0.3"/></path><path fill="none" stroke-dasharray="8" stroke-dashoffset="8" d="M12 12L16 16M12 12L8 8M12 12L8 16M12 12L16 8"><animate fill="freeze" attributeName="stroke-dashoffset" begin="0.6s" dur="0.2s" values="8;0"/></path></g></svg>
      </button>
      
      <div>
        <h2>Statystyki mojej biblioteki</h2>
        <p class="stats-p">Liczba wszystkich książek: {{ stats?.bookCount }}</p>
        <p class="stats-p">Liczba wszystkich serii: {{ stats?.seriesCount }}</p>
        <p class="stats-p">Ile żeś na to wszystko wydał: {{ stats?.sumOfPrice }} zł</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.menu {
  position: absolute;
  top: 0;
  right: 0;
  width: 100px;
  height: 100px;
}

.menu-btn {
  background-color: transparent;
  border: transparent;
  cursor: pointer;
}

.menu-btn-open {
  width: 100%;
  height: 100%;
}

.menu-btn-open svg {
  padding: 20px;
  width: 50%;
  height: 50%;
}

.menu-btn-close {
  align-self: flex-end;
  width: 75px;
  height: 75px;
  margin-right: 17px;
}

svg {
  padding: 20px 20px 10px 10px;
  width: 70%;
  height: 70%;
}

.expanded-menu {
  position: fixed;
  right: 0;
  top: 0;
  display: flex;
  align-items: center;
  flex-direction: column;
  width: 20vw;
  height: 100vh;
  background-color: #1e1c1c;
}

.stats-p {
  margin: 5px;
  padding: 10px;
}
</style>