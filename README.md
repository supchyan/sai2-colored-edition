<div align="center">
  <img src="https://github.com/supchyan/yum2-theme-toolkit/assets/123704468/6a6c2116-0c8e-4f8d-ac0f-d6c1996d273f" height="150" />
</div>
<br />

# <p align=center>SAI 2 - Colored Edition</p>
<div align="center" style="padding-left: 100px;">
<table style="width:100%">
  <th>
    <a href="https://github.com/supchyan/sai2-colored-edition/tree/main/themes/">
      <img src="https://github.com/supchyan/sai2-colored-edition/assets/123704468/e174f1c7-a8bd-424f-801e-025930177841" width="24"/>
      </br>
      <span>Theme examples</span>
    </a>  
  </th>
  <th>
    <a href="https://github.com/supchyan/sai2-colored-edition/tree/main/ref/init/data">
      <img src="https://github.com/supchyan/sai2-colored-edition/assets/123704468/691a8bad-a32d-4ef2-a8a4-d3c7e210c11e" width="24"/>
      </br>
      <span>Colors & Addresses</span>
    </a>  
  </th>
  <th>
    <a href="https://github.com/supchyan/sai2-colored-edition/releases">
      <img src="https://github.com/supchyan/sai2-colored-edition/assets/123704468/f2c7603f-030b-4dc1-8984-f49a4532097e" width="24"/>
      </br>
      <span>Releases</span>
    </a>  
  </th>
  <th>
    <a href="https://discord.gg/dGF8p9UGyM">
      <img src="https://github.com/supchyan/sai2-colored-edition/assets/123704468/037e74ed-d5cc-4f4c-b668-0c004180b3ab" width="24"/>
      </br>
      <span>My Discord</span>
    </a>  
  </th>
</table>
</div>

## Hey, listen 🧚

I'm not contributing this project right now. If you want to help with reverse-engineering, you're welcome!<br>
It's around `95%` of sai2's components are colorable with these tools, so if you fine with this, you're welcome as well! 

Check [Afterword](#afterword) section in the very end if you plan to fork this repo.

***

[Go To English Description](#introduction)

## Вступление

Набор инструментов создан на базе `sai2 64bit 2024.02.22`. То есть, это **полноценный sai2**, который поддерживает кастомные темы.

Есть вопросы? Можете задать их мне на моем [Discord Сервере](https://discord.gg/dGF8p9UGyM). Я постараюсь помочь всем, чем смогу.

Вот и все. Удачного пользования! ^^

## Установка

Скачайте последнюю версию билда [отсюда](https://github.com/supchyan/sai2-colored-edition/releases). Распакуйте файлы в любую удобную вам папку, запускайте `S2CE.exe` и всё должно работать! 😎

Для полноценной работы вам потребуется файл лицензии. Такой я вам не могу предоставить, так что это не моя головная боль.</br>
*Возможно, другой git репозиторий по саи вам поможет, но я вам этого не говорил.*

Файл лицензии должен быть помещён в папку `ref`. Называться файл лицензии может как угодно.

## Кастомные темы

О том, как их создавать, или как они выглядят "внутри" - можете ознакомиться [здесь](https://github.com/supchyan/sai2-colored-edition/tree/main/themes)

## Скриншоты

![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/26d762d6-5dab-4e9b-b3be-b87ec18cab4c)
![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/842179dc-45eb-4cbf-82fa-9aa4cf1a7106)
![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/797b709f-c0f8-446f-bd28-7c1c3caace1f)

## Разработчикам

Если вы хотите собрать этот проект из исходного кода, установите `.NET SDK 8.0+` и запустите проект через `Visual Studio`.

<div align="center">🐳</div>

## Introduction

Toolkit based on `sai2 64bit 2024.02.22`. So this is **full sai2**, which has custom themes support!

Any questions? Contact me on my [Discord Server](https://discord.gg/dGF8p9UGyM). I'll do my best.

That's all, good luck in use! ^^

## How to install

Get the latest version on [Releases](https://github.com/supchyan/sai2-colored-edition/releases) page. Download and extract folder into any location you want! Run `S2CE.exe` and enjoy 😎

To let sai2 work well, you need a license file. I can't give it to you, so it's not a my problem tho.</br>
*Probably, other git repo can help you to receive it, but I didn't say that.*

License should be placed into `ref` folder. This license file can be named as you want.

## Custom themes

Quick start guide can be found [here](https://github.com/supchyan/sai2-colored-edition/tree/main/themes)

## Screenshots

![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/dbe7efca-5865-4585-93d7-fc3541c33575)
![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/9e74f3b5-ac05-4890-bb7e-abeae43bb404)
![image](https://github.com/supchyan/sai2-colored-edition/assets/123704468/5389d452-b83f-4a30-b50d-ac655947be77)

## Development

If you want to build this project from source, you need to install `.NET SDK 8.0+` and compile this project using `Visual Studio`.

<div align="center">🐳</div>

# Afterword

I did a thing a while ago for educational purposes, it's a dll injector for sai written in cpp, so you can observe it as well. I tried to combine it together with this project and they look cool merged (all elements are painted / custom fonts support / runtime theme swap / better color picker paint tricks / etc).

* Injector by itself: https://github.com/supchyan/s2ceinjector
* DLL it injects: https://github.com/supchyan/s2cedll
