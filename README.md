# MigrateToSwimperia
Seleniumを使用して[スイムぺリア](https://swimperia.com/)へ一括登録するためのプログラムです。  
新規にスイムぺリアを始めたときに過去のデータも登録しておきたい場合にご使用ください。

**ポイント稼ぎのためにダミーデータを登録するなどの行為には絶対に使用しないでください。本プログラムは非公式のものです。スイムぺリアの運営とは一切関係ありません。**  
**不正使用や異常な量のデータ登録でスイムぺリアに迷惑をかけることは絶対におやめください。**  
**また、本プログラムの不具合などが原因で、例えばスイムぺリアのサーバーに負荷がかかり運営から責任を追及されるなどの事象が発生しても、当方(本プログラム作成者)では一切の責任を負いません。自己責任でご利用ください。**

## 使い方
1. MigrateToSwimperia/importdata.xlsxのExcelファイルに登録したいデータを記入します。（記入方法は見たらわかるレベルです）
2. 設定ファイルSettings1にログイン情報を記載します。
3. MigrateToSwimperia/Program.csの24行目のファイル名（パス）を必要に応じて変更します。
4. 実行します。
※正常に動作することを確認するために、56行目をコメントアウトして一旦投稿しない状態で実行してみることをおすすめします。スイムぺリアは投稿の削除は管理人への依頼となり手間がかかりますので、誤投稿にはご注意ください。

## スイムぺリア運営の方へ
もしこのプログラムが不適切でやめてほしいということであれば、issueを起票するなどしてご連絡ください。指示に従います。
