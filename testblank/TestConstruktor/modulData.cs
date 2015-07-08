﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recog.TestConstruktor
{
  public  class modulData
    {
      public List<ans> answers = new List<ans>();
      private void Add(bool _isyes,int _nom, string _text, double _mark)
      {
          ans a = new ans();
          a.nom = _nom;
          a.text = _text;
          a.Mark = _mark;
          a.isYes = _isyes;
          answers.Add(a);
      }
      public modulData()
      {
          Add(true,1, "1. Я хорошо понял инструкцию к выполнению данной методики.", 1);
          Add(true, 2, "2. У меня часто меняется настроение от безразличного отношения к жизни до отвращения к ней.", 3);
          Add(false, 3, "3. Аппетит у меня хороший.", 1);
          Add(true, 4, "4. Я легко просыпаюсь от шума.", 1);
          Add(false, 5, "5. Сейчас я примерно также работоспособен, как и всегда.", 1);
          Add(true, 6, "6. Мне часто кажется, что у меня комок в горле.", 1);
          Add(true, 7, "7. Человек должен стараться понимать свои сны, руководствоваться ими в жизни и извлекать из них предостережения.", 1);
          Add(true, 8, "8. У меня часто беспричинно меняется настроение.", 1);
          Add(true, 9, "9. Работа стоит мне большого напряжения.", 1);
          Add(true, 10, "10. Определённо судьба не справедлива ко мне.", 2);
          Add(true, 11, "11. Временами мне очень хотелось покинуть дом.", 2);
          Add(true, 12, "12. Временами у меня бывают приступы смеха или плача, с которыми я никак не могу справиться.", 4);
          Add(true, 13, "13. У меня бывают приступы тошноты и рвоты.", 1);
          Add(true, 14, "14. Мне кажется, что меня никто не понимает.", 2);
          Add(true, 15, "15. Временами в меня вселяется злой дух.", 4);
          Add(true, 16, "16. Считаю, что если кто-то причинил мне зло, я должен отплатить ему тем же.", 3);
          Add(true, 17, "17. Несколько раз в неделю у меня бывает изжога.", 1);
          Add(false,18, "18. Иногда мне хочется выругаться.", 1);
          Add(true, 19, "19. Два - три раза в неделю по ночам меня мучают кошмары.", 1);
          Add(true, 20, "20. Часто бывает, что я засыпаю в хорошем настроении, а утром просыпаюсь в мрачном.", 2);
          Add(false, 21, "21. Я воспитывался в полной семье.", 1);
          Add(true, 22, "22. У меня бывали странные и необычные переживания.", 2);
          Add(true, 23, "23. Я кашляю очень часто.", 5);
          Add(true, 24, "24. Если бы люди не были настроены против меня, я достиг бы в жизни гораздо большего.", 2);
          Add(true, 25, "25. Моим воспитанием занимались другие родственники (не родные родители).", 1);
          Add(true, 26, "26. При приёме алкоголя моё настроение меняется.", 2);
          Add(true, 27, "27. В детстве я одно время совершал мелкие кражи.", 2);
          Add(true, 28, "28. Бывает, у меня появляется желание ломать и крушить всё вокруг.", 3);
          Add(true, 29, "29. Чаще всего мне бы хотелось сидеть и мечтать, нежели заниматься чем-либо другим.", 2);
          Add(true, 30, "30. Бывало, что я целыми днями или даже неделями ничего не мог делать, потому что никак не мог заставить себя взяться за работу.", 1);
          Add(true, 31, "31. Бывает, что я беспричинно нахожусь в ворчливом настроении, в котором со мной лучше не разговаривать.", 2);
          Add(true, 32, "32. Сон у меня прерывистый и беспокойный.", 1);
          Add(true, 33, "33. Голова у меня болит часто.", 1);
          Add(false, 34, "34. Я не всегда говорю правду", 1);
          Add(true, 35, "35. Раз в неделю или чаще я безо всякой видимой причины внезапно ощущаю жар во всём теле.", 1);
          Add(true, 36, "36. Когда я нахожусь среди людей, я слышу очень странные вещи.", 4);
          Add(true, 37, "37. Было бы хорошо, если бы почти все законы отменили.", 2);
          Add(true, 38, "38. У меня часто возникает чувство сильного внутреннего беспокойства, ощущение возможной беды, неприятности.", 2);
          Add(true, 39, "39. Иногда моя душа покидает тело.", 5);
          Add(true, 40, "40. Я верю, что некоторые люди могут прикосновением излечить болезнь.", 2);
          Add(false, 41, "41. Боли в сердце или груди у меня бывают очень редко (или не бывают совсем).", 1);
          Add(true, 42, "42. Я быстро впадаю в гнев.", 2);
          Add(true, 43, "43. В детстве меня исключали из школы за плохое поведение.", 4);
          Add(true, 44, "44. Я воспитывался в интернате.", 1);
          Add(true, 45, "45. В различных частях своего тела я часто чувствую жжение, покалывание, «ползание мурашек» или онемение.", 5);
          Add(true, 46, "46. Иногда я так настаиваю на своём, что люди теряют терпение.", 2);
          Add(true, 47, "47. В детстве я убегал из дома.", 3);
          Add(true, 48, "48. Я вижу вокруг себя предметы, животных, людей, которых другие не видят.", 3);
          Add(true, 49, "49. Я бы хотел быть таким же счастливым, какими мне кажутся другие.", 2);
          Add(true, 50, "50. Несколько раз в неделю меня беспокоят неприятные ощущения в верхней части живота (под ложечкой).", 1);
          Add(true, 51, "51. Я становлюсь менее сдержанным и чувствую себя более свободно, если приму алкоголь.", 2);
          Add(true, 52, "52. Я человек значительный.", 2);
          Add(true, 53, "53. Меня воспитывали очень строго, требовательно.", 2);
          Add(false, 54, "54. Иногда я бываю сердитым.", 1);
          Add(true, 55, "55. Большую часть времени настроение у меня подавленное.", 4);
          Add(true, 56, "56. Я часто импульсивно и необдуманно совершал такие поступки, которые приносили мне неприятности.", 4);
          Add(true, 57, "57. Теперь мне уже трудно надеяться на то, что я чего-нибудь добьюсь в жизни.", 3);
          Add(true, 58, "58. Иногда меня так привлекают чужие вещи (туфли, перчатки и т. п.), что мне хочется подержать их в руках или даже украсть, хоть они мне и не нужны.", 3);
          Add(true, 59, "59. У меня мало уверенности в себе.", 2);
          Add(true, 60, "60. В коллективе сверстников я не пользовался авторитетом, чаще отвергался.", 2);
          Add(false, 61, "61. Иногда я откладываю на завтра то, что должен сделать сегодня.", 1);
          Add(true, 62, "62. Временами я испытываю сильное желание нарушить правила приличия или кому-нибудь навредить.", 2);
          Add(false, 63, "63. Свое сексуальное развитие я оцениваю как гармоничное, без отклонений.", 1);
          Add(true, 64, "64. Иногда мне так и хочется сделать себе больно.", 5);
          Add(true, 65, "65. Я довольно безразличен к тому, что со мной будет.", 2);
          Add(false, 66, "66. Иногда, когда я себя плохо чувствую, я бываю раздражительным.", 1);
          Add(true, 67, "67. Большую часть времени у меня такое чувство, будто я сделал что-то не то или даже что-то плохое.", 3);
          Add(true, 68, "68. Когда я стою на мосту, то меня иногда так и тянет прыгнуть вниз.", 3);
          Add(false, 69, "69. Большую часть времени я вполне доволен жизнью.", 2);
          Add(true, 70, "70. Большую часть времени меня беспокоит ощущение чего-то постороннего в носу или голове.", 4);
          Add(true, 71, "71. Кое-кто рад бы мне навредить.", 2);
          Add(true, 72, "72. У меня часто бывает такое чувство, будто моя голова стянута обручем.", 1);
          Add(true, 73, "73. Когда я злюсь, то мне хочется кого-нибудь ударить.", 4);
          Add(false, 74, "74. В гостях я держусь за столом лучше, чем дома.", 1);
          Add(true, 75, "75. По-моему, против меня что-то замышляют.", 2);
          Add(true, 76, "76. Я знаю, что за мной следят.", 5);
          Add(true, 77, "77. Мой желудок сильно беспокоит меня.", 1);
          Add(true, 78, "78. Возможность чем-нибудь заразиться меня сильно беспокоит.", 2);
          Add(true, 79, "79. Я никогда не забываю и не прощаю тех, кто сделал мне зло.", 3);
          Add(true, 80, "80. Временами мои мысли проносятся быстрее, чем я успеваю их высказывать.", 3);
          Add(false, 81, "81. Если мне не грозит штраф, и машин поблизости нет, я могу перейти улицу там, где мне хочется, а не там, где положено.", 1);
          Add(false, 82, "82. В целом я удовлетворён своим семейным положением.", 1);
          Add(true, 83, "83. Иногда у меня бывает такое чувство, что я просто должен нанести повреждение себе самому или кому-нибудь другому.", 5);
          Add(true, 84, "84. Временами я бываю совершенно уверен в своей никчёмности.", 2);
          Add(true, 85, "85. Иногда меня так и подмывает затеять с кем-нибудь драку.", 4);
          Add(true, 86, "86. Мне легко заставить других людей бояться меня, и иногда ради забавы я это делаю.", 4);
          Add(false, 87, "87. В игре мне приятнее выигрывать, чем проигрывать.", 1);
          Add(true, 88, "88. Кто-то пытается меня отравить.", 3);
          Add(false, 89, "89. Обычно я засыпаю спокойно, и меня не тревожат никакие мысли.", 1);
          Add(false, 90, "90. Последние несколько лет большую часть времени я чувствую себя хорошо.", 1);
          Add(false, 91, "91. Иногда у меня бывает такое настроение, что я готов первым начать драку.", 2);
          Add(false, 92, "92. У меня никогда не было ни припадков, ни судорог", 1);
          Add(true, 93, "93. Мой вес постоянно меняется, я то худею, то полнею.", 1);
          Add(false, 94, "94. Я чувствую удовлетворение от профессиональной (учебной) деятельности.", 1);
          Add(true, 95, "95. Я сильно устаю.", 1);
          Add(true, 96, "96. Мне нравится детально изучать то, чем я занимаюсь, и читать об этом.", 2);
          Add(false, 97, "97. Мне нравится иметь значительных людей среди моих знакомых, так как это повышает мой престиж.", 1);
          Add(true, 98, "98. Мне страшно смотреть вниз с большой высоты.", 1);
          Add(true, 99, "99. Я был бы довольно спокоен, если бы у кого-нибудь из членов моей семьи были неприятности из-за нарушения закона.", 1);
          Add(true, 100, "100. С моим рассудком творится что-то неладное.", 5);
          Add(false, 101, "101. Материальное положение моей семьи оставляет желать лучшего.", 1);
          Add(true, 102, "102. Я боюсь сойти с ума.", 1);
          Add(true, 103, "103. Обычно я слышу голоса, не зная, откуда они идут.", 4);
          Add(true, 104, "104. Когда я пытаюсь что-то сделать, то часто замечаю, что у меня дрожат руки.", 1);
          Add(true, 105, "105. Большую часть времени я испытываю общую слабость.", 1);
          Add(true, 106, "106. Я могу вспомнить случаи, когда я был таким злым, что хватал первую попавшуюся под руку вещь и ломал её.", 3);
          Add(true, 107, "107. Иногда, когда я смущён, я сильно потею, и это меня раздражает.", 1);
          Add(false, 108, "108. Не все, кого я знаю, мне нравятся.", 1);
          Add(true, 109, "109. Кто-то пытается меня ограбить.", 3);
          Add(true, 110, "110. Есть люди, которые пытаются украсть мои мысли и идеи.", 3);
          Add(true, 111, "111. Думаю, что я человек обречённый.", 3);
          Add(true, 112, "112. Бывали случаи, когда мне было трудно удержаться от того, чтобы что-нибудь не стащить у кого-либо или где-либо, например в магазине.", 3);
          Add(true, 113, "113. Я знаю, что мои прегрешения простить нельзя.", 2);
          Add(true, 114, "114. Всё мне кажется одинаковым на вкус.", 1);
          Add(true, 115, "115. Я могу спать только днём, а ночью не могу.", 5);
          Add(true, 116, "116. При ходьбе я стараюсь не наступать даже на небольшие трещины в тротуаре.", 2);
          Add(true, 117, "117. Иногда я бываю так раздражителен, что стучу по столу кулаком.", 2);
          Add(false, 118, "118. У меня на коже никогда не было каких-либо высыпаний (прыщиков, угрей и т.п.), которые бы меня тревожили.", 1);
          Add(false, 119, "119. Иногда я могу немного посплетничать.", 1);
          Add(true, 120, "120. Мне говорили, что я хожу во сне.", 1);
          Add(false, 121, "121. Я редко задыхаюсь, и у меня не бывает сильных сердцебиений.", 1);
          Add(true, 122, "122. Я часто предаюсь грустным размышлениям.", 2);
          Add(true, 123, "123. Временами я не могу справиться с желанием причинить боль другим людям.", 5);
          Add(true, 124, "124. У меня бывают периоды такого сильного беспокойства, что я даже не могу усидеть на месте.", 2);
          Add(true, 125, "125. У меня на шее часто выступают красные пятна.", 1);
          Add(true, 126, "126. Иногда без всякой причины или даже когда дела идут плохо, я чувствую себя радостно-возбуждённым и счастливым.", 2);
          Add(true, 127, "127. Конфликты на работе (учёбе) очень тревожат меня.", 1);
          Add(true, 128, "128. Люди безразличны и равнодушны к тому, что с тобой случится.", 2);
          Add(true, 129, "129. Несколько раз у меня были неприятности с законом.", 4);
          Add(true, 130, "130. Я очень легко потею даже в прохладные дни.", 1);
          Add(true, 131, "131. Раз в неделю или чаще я бываю очень возбуждённым и взволнованным.", 2);
          Add(true, 132, "132. Когда я ухожу из дома, по несколько раз проверяю, заперта ли дверь, выключен ли свет, иногда возвращаюсь, что бы перепроверить.", 3);
          Add(true, 133, "133. Моя кожа в некоторых местах бывает нечувствительной.", 1);
          Add(true, 134, "134. Кто-то управляет моими мыслями.", 5);
          Add(true, 135, "135. Я ежедневно выпиваю необычайно много воды.", 1);
          Add(true, 136, "136. В детстве я был болезненным слабым ребёнком.", 1);
          Add(true, 137, "137. Бывает, что я испытываю ненависть к членам моей семьи, которых обычно люблю.", 2);
          Add(true, 138, "138. Уверен, что за моей спиной обо мне говорят.", 2);
          Add(false, 139, "139. Бывает, что я смеюсь по поводу вольной (неприличной) шутки.", 1);
          Add(true, 140, "140. Счастливее всего я бываю, когда я один.", 1);
          Add(true, 141, "141. Даже когда мне ещё не было 15 лет, я уже совершал поступки, за которые меня можно было посадить в тюрьму.", 5);
          Add(true, 142, "142. Работа стоит мне большого напряжения.", 1);
          Add(true, 143, "143. В моей жизни был один или несколько случаев, когда я чувствовал, что кто-то посредством гипноза заставляет меня совершать те или иные поступки.", 3);
          Add(true, 144, "144. Кто-то пытается воздействовать на мои мысли.", 5);
          Add(true, 145, "145. Если человек в меру и без вредных последствий употребляет возбуждающие и влияющие на психику вещества – это вполне нормально.", 3);
          Add(true, 146, "146. В моей жизни было одно или несколько психотравмирующих событий, которые произвели на меня неизгладимое впечатление.", 2);
          Add(true, 147, "147. Иногда совершенно безо всякой причины у меня вдруг наступает период необычайной весёлости.", 2);
          Add(true, 148, "148. Мне кажется, что я всё чувствую более остро, чем другие.", 1);
          Add(true, 149, "149. Человек должен иметь право выпивать, сколько он хочет и где хочет.", 3);
          Add(true, 150, "150. В школе мне было очень трудно говорить перед классом.", 2);
          Add(true, 151, "151. Даже среди людей я обычно чувствую себя одиноким.", 3);
          Add(true, 152, "152. Мне неприятно, когда вокруг меня люди.", 2);
          Add(true, 153, "153. Определённо, судьба несправедлива ко мне.", 3);
          Add(true, 154, "154. Меня легко привести в замешательство.", 2);
          Add(true, 155, "155. Некоторые правила и запреты можно отбросить, если испытываешь сильное сексуальное влечение.", 3);
          Add(true, 156, "156. Иногда у меня пропадает или меняется голос, даже если я не простужен.", 1);
          Add(true, 157, "157. Мне кажется, что меня никто не понимает.", 3);
          Add(true, 158, "158. Временами я ощущаю странные запахи.", 2);
          Add(true, 159, "159. Я легко теряю терпение с людьми.", 2);
          Add(true, 160, "160. Я почти всегда о чем-нибудь или о ком-нибудь тревожусь.", 2);
          Add(true, 161, "161. Определённо, на мою долю выпало больше забот и беспокойства, чем положено.", 2);
          Add(true, 162, "162. Часто мне хочется умереть.", 5);
          Add(true, 163, "163. Иногда я бываю так возбуждён, что мне трудно заснуть.", 2);
          Add(true, 164, "164. Часто я перехожу на другую сторону улицы, чтобы избе жать встречи с кем-либо, кого я увидел.", 3);
          Add(true, 165, "165. Часто у меня бывает такое ощущение, будто всё вокруг нереально.", 5);
          Add(true, 166, "166. Правы люди, которые в жизни следуют пословице: «Если нельзя, но очень хочется, то можно».", 3);
          Add(true, 167, "167. У меня есть привычка считать всякие случайные предметы, такие как окна, фонари и т.п., от которой не могу избавиться.", 2);
          Add(true, 168, "168. У меня бывают странные, необычные мысли.", 2);
          Add(true, 169, "169. Когда вокруг никого нет, я слышу странные вещи.", 5);
          Add(true, 170, "170. Если мне предстоит хотя бы ненадолго уехать из дома, у меня на душе становится тревожно.", 1);
          Add(true, 171, "171. Есть вещи или люди, к которым я отношусь с опаской, хоть и знаю, что они не таят для меня никакой угрозы.", 1);
          Add(true, 172, "172. Мне очень трудно войти в комнату, где уже собрались и разговаривают другие люди.", 3);
          Add(true, 173, "173. Я опасаюсь пользоваться ножом или другими острыми или колющими предметами.", 1);
          Add(true, 174, "174. Бывает, что мне в голову приходят плохие, часто даже ужасные слова, и я никак не могу от них отвязаться.", 2);
          Add(true, 175, "175. Удовольствие – это главное, к чему следует стремиться в жизни.", 2);
          Add(true, 176, "176. Иногда какой-нибудь пустяк овладевает моими мыслями и несколько дней не даёт мне покоя.", 2);
          Add(true, 177, "177. Почти каждый день случается что-нибудь, что пугает меня.", 3);
          Add(true, 178, "178. Некоторые из моих родственников страдали психическими расстройствами, состояли на учёте в психоневрологическом, наркологическом диспансере.", 2);
          Add(true, 179, "179. Обо мне говорят пошлые и оскорбительные вещи.", 3);
          Add(true, 180, "180. Когда я нахожусь в помещении, я чувствую себя как-то тревожно и неспокойно.", 1);
          Add(true, 181, "181. Меня сильно пугают некоторые вещи (молнии, гроза, огонь, вода, темнота, пауки, мыши или что-то другое).", 2);
          Add(true, 182, "182. Иногда я стараюсь держаться подальше от того или иного человека, чтобы не сделать или не сказать чего-нибудь такого, о чём потом пожалею.", 3);
          Add(true, 183, "183. Секс должен занимать в жизни молодёжи одно из главных мест.", 2);
          Add(true, 184, "184. Временами мне кажется, что моя голова работает медленнее, чем обычно.", 2);
          Add(true, 185, "185. У меня были черепно-мозговые травмы.", 1);
          Add(true, 186, "186. Я бы хотел перестать терзаться из-за того, что те или иные сказанные мною слова могли показаться кому-нибудь обидными.", 3);
          Add(true, 187, "187. Часто даже когда всё складывается для меня хорошо, я чувствую, что мне всё безразлично.", 3);
          Add(true, 188, "188. Иногда у меня бывает чувство, что передо мной нагромоздилось столько трудностей, что одолеть их просто невозможно.", 2);
          Add(false, 189, "189. Затруднения при глотании у меня отсутствуют.", 1);
          Add(true, 190, "190. Я заслуживаю сурового наказания за свои прегрешения.", 3);
          Add(true, 191, "191. Мне свойственно так сильно переживать свои разочарования, что я не могу себя заставить не думать о них.", 2);
          Add(true, 192, "192. Временами мне кажется, что я ни на что не годен.", 2);
          Add(true, 193, "193. Периодически я прохожу лечение по поводу хронического соматического заболевания.", 2);
          Add(true, 194, "194. У меня были очень необычные мистические переживания.", 4);
          Add(true, 195, "195. Я почти всё время испытываю чувство голода.", 1);
          Add(true, 196, "196. Меня весьма беспокоят возможные несчастья.", 3);
          Add(true, 197, "197. Бывало, что я придумывал себе товарищей.", 1);
          Add(true, 198, "198. В последнее время, чтобы не «сорваться», я вынужден был принимать успокаивающие лекарства.", 3);
          Add(true, 199, "199. У меня бывали периоды, когда из-за волнения я терял сон.", 3);
          Add(true, 200, "200. Я люблю играть в азартные игры на небольшие ставки.", 2);
          Add(false, 201, "201. Мочеиспускание у меня происходит без каких-либо затруднений, и при необходимости я могу потерпеть.", 1);
          Add(true, 202, "202. Я часто запоминаю числа, не имеющие для меня никакого значения (например, номера автомашин и т.п.).", 2);
          Add(true, 203, "203. В моём роду были случаи самоубийств.", 2);
          Add(true, 204, "204. По возможности, я стараюсь избегать большого скопления людей.", 2);
          Add(true, 205, "205. Я призван совершить великую миссию.", 3);
          Add(true, 206, "206. Я понимаю людей, которые полностью отдаются своим горестям, заботам.", 2);
          Add(true, 207, "207. У меня есть хобби.", 1);
          Add(true, 208, "208. Я боюсь находиться в чулане или другом маленьком закрытом помещении.", 1);
          Add(true, 209, "209. Бывали периоды, когда я чувствовал себя настолько полным энергии, что казалось, мог бы обходиться без сна несколько суток.", 3);
          Add(true, 210, "210. Всякая грязь пугает меня или вызывает у меня отвращение.", 4);
          Add(true, 211, "211. У меня есть свой особый воображаемый мир, о котором я никому не рассказываю.", 5);
          Add(true, 212, "212. Я часто испытываю потребность в острых ощущениях.", 3);
          Add(true, 213, "213. С моими половыми органами что-то неладно.", 4);
          Add(true, 214, "214. В детстве у меня было одно или несколько перечисленных расстройств: энурез, заикание, снохождение, сноговорение.", 2);
          Add(true, 215, "215. Я берусь за дверные ручки, испытывая страх чем-нибудь заразиться.", 4);
          Add(true, 216, "216. Сигарета в трудную минуту меня успокаивает.", 1);
          Add(true, 217, "217. Я краснею чаще, чем другие.", 1);
          Add(true, 218, "218. Я часто боюсь покраснеть.", 1);
          Add(true, 219, "219. Я состоял на учёте в детской комнате милиции.", 2);
          Add(false, 220, "220. Отрыжка у меня бывает редко (или не бывает совсем).", 1);
          Add(true, 221, "221. Я почти всегда ощущаю сухость во рту.", 1);
          Add(true, 222, "222. Мне кажется, что моя кожа чрезвычайно чувствительна к прикосновению.", 1);
          Add(true, 223, "223. Несколько раз в неделю у меня бывает такое чувство, что должно случиться что-то страшное.", 3);
          Add(true, 224, "224. Большую часть времени я чувствую себя уставшим.", 1);
          Add(true, 225, "225. Вредное воздействие алкоголя и табака на человека сильно преувеличивают.", 1);
          Add(true, 226, "226. Я пробовал некоторые наркотики ради интереса.", 1);
          Add(true, 227, "227. Иногда я бываю уверен, что другие люди знают, о чем я думаю.", 2);
          Add(true, 228, "228. Не могу заставить себя бросить курить, хотя знаю, что это вредно.", 2);
          Add(true, 229, "229. Иногда я чувствую, что близок к нервному срыву.", 2);
          Add(true, 230, "230. Часто среди ночи меня охватывает страх.", 3);
          Add(true, 231, "231. Когда я нахожусь на высоком месте, у меня появляется желание прыгнуть вниз.", 3);
          Add(true, 232, "232. Как бы я не старался, мне было очень трудно усваивать учебную программу.", 1);
          
      }
    }
  public class ans
  {
      public int nom;
      public string text;
      public double Mark;
      public bool isYes;
  }
}
