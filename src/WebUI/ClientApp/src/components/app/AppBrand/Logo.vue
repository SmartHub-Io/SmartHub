<script lang="ts">
import { computed, defineComponent, toRefs } from 'vue';

export default defineComponent({
  name: 'Logo',
  props: {
    width: {
      type: Number,
      default: 40
    }
  },
  setup(props) {
    const getHeight = computed(() => Math.ceil((props.width / 48) * 48));

    return {
      ...toRefs(props),
      getHeight
    };
  }
});
</script>

<template>
  <svg
    :width="width"
    :height="getHeight"
    viewBox="0 0 300 300"
    version="1.1"
    xmlns="http://www.w3.org/2000/svg"
    xmlns:xlink="http://www.w3.org/1999/xlink"
    xml:space="preserve"
    xmlns:serif="http://www.serif.com/"
    style="fill-rule: evenodd; clip-rule: evenodd; stroke-linejoin: round; stroke-miterlimit: 2"
  >
    <rect x="0" y="0" width="300" height="300" style="fill: none" />
    <g transform="matrix(10.5712,0,0,10.5712,-19.1396,-19.1429)">
      <g id="_15ec454d-95be-4c6e-b6d2-8ac655518624" serif:id="15ec454d-95be-4c6e-b6d2-8ac655518624">
        <g>
          <path
            d="M6,13C5.451,13 5,13.451 5,14L5,27C5.002,28.645 6.355,29.998 8,30L24,30C25.645,29.998 26.998,28.645 27,27L27,14C27,13.451 26.549,13 26,13C25.451,13 25,13.451 25,14L25,27C24.999,27.548 24.548,27.999 24,28L8,28C7.452,27.999 7.001,27.548 7,27L7,14C7,13.451 6.549,13 6,13Z"
            style="fill: url(#_Linear1); fill-rule: nonzero"
          />
          <path
            d="M3.57,12.822L16,4.216L28.43,12.822C28.597,12.938 28.796,13 29,13C29.549,13 30,12.549 30,12C30,11.672 29.839,11.365 29.57,11.178L16.57,2.178C16.228,1.941 15.772,1.941 15.43,2.178L2.43,11.178C2.161,11.365 2,11.672 2,12C2,12.549 2.451,13 3,13C3.204,13 3.403,12.938 3.57,12.822ZM13.874,22.892C13.697,23.078 13.598,23.325 13.598,23.582C13.598,24.13 14.05,24.582 14.598,24.582C14.864,24.582 15.118,24.476 15.306,24.288C15.692,23.918 16.308,23.918 16.694,24.288C16.882,24.476 17.136,24.582 17.402,24.582C17.95,24.582 18.402,24.13 18.402,23.582C18.402,23.325 18.303,23.078 18.126,22.892C16.949,21.75 15.051,21.75 13.874,22.892Z"
            style="fill: url(#_Linear2); fill-rule: nonzero"
          />
          <path
            d="M19.54,22.46C20.089,22.46 20.54,22.009 20.54,21.46C20.54,21.193 20.433,20.937 20.243,20.749C17.91,18.433 14.09,18.433 11.757,20.749C11.56,20.938 11.448,21.199 11.448,21.472C11.448,22.02 11.9,22.472 12.448,22.472C12.717,22.472 12.975,22.363 13.163,22.171C14.744,20.67 17.256,20.67 18.837,22.171C19.024,22.356 19.277,22.46 19.54,22.46Z"
            style="fill: url(#_Linear3); fill-rule: nonzero"
          />
          <path
            d="M21.66,20.34C21.66,20.34 21.661,20.34 21.661,20.34C22.209,20.34 22.661,19.889 22.661,19.34C22.661,19.073 22.554,18.818 22.365,18.63C18.87,15.145 13.13,15.145 9.635,18.63C9.446,18.818 9.339,19.074 9.339,19.34C9.339,19.889 9.791,20.341 10.34,20.341C10.604,20.341 10.858,20.236 11.045,20.05C13.765,17.336 18.235,17.336 20.955,20.05C21.142,20.236 21.396,20.341 21.66,20.34Z"
            style="fill: url(#_Linear4); fill-rule: nonzero"
          />
        </g>
      </g>
    </g>
    <defs>
      <linearGradient
        id="_Linear1"
        x1="0"
        y1="0"
        x2="1"
        y2="0"
        gradientUnits="userSpaceOnUse"
        gradientTransform="matrix(19.9388,9.2976,-9.2976,19.9388,-0.962498,13.8951)"
      >
        <stop offset="0" style="stop-color: rgb(78, 26, 112); stop-opacity: 1" />
        <stop offset="1" style="stop-color: rgb(43, 76, 242); stop-opacity: 1" />
      </linearGradient>
      <linearGradient
        id="_Linear2"
        x1="0"
        y1="0"
        x2="1"
        y2="0"
        gradientUnits="userSpaceOnUse"
        gradientTransform="matrix(25.3771,11.8336,-11.8336,25.3771,0.967093,2.65777)"
      >
        <stop offset="0" style="stop-color: rgb(78, 26, 112); stop-opacity: 1" />
        <stop offset="1" style="stop-color: rgb(43, 76, 242); stop-opacity: 1" />
      </linearGradient>
      <linearGradient
        id="_Linear3"
        x1="0"
        y1="0"
        x2="1"
        y2="0"
        gradientUnits="userSpaceOnUse"
        gradientTransform="matrix(8.23969,3.84223,-3.84223,8.23969,2.34095,22.0688)"
      >
        <stop offset="0" style="stop-color: rgb(78, 26, 112); stop-opacity: 1" />
        <stop offset="1" style="stop-color: rgb(43, 76, 242); stop-opacity: 1" />
      </linearGradient>
      <linearGradient
        id="_Linear4"
        x1="0"
        y1="0"
        x2="1"
        y2="0"
        gradientUnits="userSpaceOnUse"
        gradientTransform="matrix(12.0733,5.62985,-5.62985,12.0733,1.69549,18.463)"
      >
        <stop offset="0" style="stop-color: rgb(78, 26, 112); stop-opacity: 1" />
        <stop offset="1" style="stop-color: rgb(43, 76, 242); stop-opacity: 1" />
      </linearGradient>
    </defs>
  </svg>
</template>
