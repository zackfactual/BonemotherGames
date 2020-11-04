<template>
  <div id="app">
    <retainer-page />
  </div>
</template>

<script>
    import RetainerPage from './components/retainer/RetainerPage.vue'

export default {
  name: 'app',
  components: {
      RetainerPage
  }
}
</script>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
