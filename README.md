# Introduction
A Bingo simulation using the Monte Carlo method.

![top_img_irasutoya](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/bingo.png)

hiraxさんの[hirax.net::モンテカルロでビンゴ大会::(2001.12.17)](http://www.hirax.net/dekirukana6/bingo/)をふと思い出したので行ってみました。ビンゴするまでビンゴカードを開けた回数とビンゴした確率のグラフ（確率分布）を作ってみました。

# Condition

1枚のビンゴカード（5×5、真ん中がFREE）がビンゴするまで何回番号を開けたかを数える。これを10000回実行する。

* 1～75までのビンゴカード

|1列目(1 to 15)|2列目(16 to 30)|3列目(31 to 45)|4列目(46 to 60)|5列目(61 to 75)|
|---|---|---|---|---|
|1|16|31|46|61|
|…|…|…|…|…|
|…|…|FREE|…|…|
|…|…|…|…|…|
|…|…|…|…|…|

* 1～99までのビンゴカード（列に関係なくランダム）

|1列目|2列目|3列目|4列目|5列目|
|---|---|---|---|---|
|87|24|…|…|…|
|…|…|…|…|…|
|…|…|FREE|…|…|
|…|…|…|…|…|
|…|…|…|…|…|

# Result

1～75までのビンゴカードの場合、40回目の番号読み上げでビンゴする人がピークとなる。

![result](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/bingo_img1.png)

確率分布にしたのが以下。40回目では半分の人がビンゴしていることに。

![result2](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/bingo_img2.png)

# Refference
1. [hirax.net::モンテカルロでビンゴ大会::(2001.12.17)](http://www.hirax.net/dekirukana6/bingo/)


