module.exports = {
  content: ["./src/**/*.{html,js}"],
  theme: {
    screens:{
      "tv":{max:'1200px'},
      "pc":{max:'992px'},
      "laptop":{max:'768px'},
      "tablet":{max:'640px'},
      "iphone":{max:'480px'},
      "galaxy":{max:'360px'},
      "ipad":{max:'320px'}
    },
    extend: {
      colors:{
        "hover":"#09b9bb",
        'black-text':"#333333",
        "white":"#fff",
        'gray' : '#EEEEEE',
        'light-gray' : '#ccc',
        'dark-gray':'#222534' ,
        'transparent' : "transparent"
      }
    },
  },
  plugins: [
    require('@tailwindcss/line-clamp'),
  ],
}
