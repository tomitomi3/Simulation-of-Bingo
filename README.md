# Introduction
A Bingo simulation using the Monte Carlo method.

hiraxさんの[hirax.net::モンテカルロでビンゴ大会::(2001.12.17)](http://www.hirax.net/dekirukana6/bingo/)をふと思い出したので行ってみました。
ビンゴするまで番号を開けた回数を累積したグラフ（確率分布）を作ってみました。

# Condition

1枚のビンゴカード（5×5、真ん中がFREE）がビンゴするまで何回番号を開けたかを数える。これを1000回実行する。

# Result

青がシミュレーション結果。

赤はシグモイド曲線にフィッティングしそうだったのであてはめた結果。

![resultwithoutsigmoid](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/bingorateresult_withoutsigm.png)

![result](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/bingorateresult.png)

* ここで用いたシグモイド関数は下記の数式のもの。標準のシグモイド関数に定数倍と原点移動の変数を追加したもの。

![sigmoid](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/model_sigmoid.png)

* フィッティングした結果

![sigmoid_fitting](https://github.com/tomitomi3/Simulation-of-Bingo/blob/master/_img/model_sigmoid_fitting.png)

# Refference
1. [hirax.net::モンテカルロでビンゴ大会::(2001.12.17)](http://www.hirax.net/dekirukana6/bingo/)


