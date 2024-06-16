<script setup lang="ts">
import Book from "../Models/Book.ts";
import { ref, watch } from "vue";

defineProps<{
  book: Book
}>();

const bookDescShow = ref(false);
const bookBg = ref<HTMLDivElement | undefined>(undefined);

watch(bookBg, () => {  
  bookBg.value?.focus();
})
</script>

<template>
  <div @click="bookDescShow = true" class="book">
    {{ book.name }}
  </div>
  
  <div v-if="bookDescShow" class="book-desc-container">
    <div ref="bookBg" @click="bookDescShow = false" @keydown.esc="bookDescShow = false" tabindex="0" class="book-bg" />
    <div class="book-desc">
      <div>
        <h2>{{ book.name }}</h2>
        <p>Seria: {{ book.seriesName }}</p>
        <p>Cena: {{ book.price }}zł</p>
        <p>Autor: {{ book.authorName }}</p>
        <p>Wydawca: {{ book.publishingHouseName }}</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.book-desc {
  position: relative;
  min-width: 35%;
  background-color: #242424;
  padding: 50px;
  border-radius: 10px;
}

.book-desc-container {
  position: fixed;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.book-bg:focus {
  outline: none;
}

.book-bg {
  position: fixed;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  background: rgba(23, 23, 23, 0.8);
}

img {
  stroke: white;
}

.book {
  margin: 5px;
  border: #535bf2 3px solid;
  border-radius: 5px;
  word-wrap: break-word;
  max-width: 38px;
  max-height: 20vh;
  min-height: 10vh;
  min-width: 28px;
  overflow: clip;
  padding: 2px;
}

.book:hover {
  background: #323792;
}
</style>