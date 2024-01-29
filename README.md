# PLATEAU SDK Toolkits for Unity

<img width="1080" alt="toolkits_key_visual" src="/Documentation~/Images/toolkits_key_visual.png">


PLATEAU SDK-Toolkits for Unityは、PLATEAUの提供する「3D都市モデル」のデータを利用したUnity上でのアプリケーション開発を支援するツールキット群です。  
**PLATEAU SDK-Toolkits for Unityは[PLATEAU SDK for Unity](https://github.com/Project-PLATEAU/PLATEAU-SDK-for-Unity)を前提とするアドオンです。**

[ダウンロードリンクはこちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/releases/)


## Toolkitsの構成要素
PLATEAU SDK-Toolkits for Unityは以下の4つのコンポーネントから構成されます。
2023年度の開発はアジャイル方式で行われます。  
**年度内に4回程度、各Toolkitのベータ版をリリースし、ユーザの皆様からのフィードバックを開発に反映する予定です。**  
ベータ版についてのご意見やバグ報告等は、本リポジトリのIssues又はPull requestsをご利用ください。  

- [Rendering Toolkit](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/PlateauToolkit.Rendering)
- [Sandbox Toolkit](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/PlateauToolkit.Sandbox)
- [PLATEAU Utilities ※リンク要修正](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/)
- [Maps Toolkit](https://github.com/Project-PLATEAU/PLATEAU-SDK-Maps-Toolkit-for-Unity)（別リポジトリ）
- [AR Extensions](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity)（別リポジトリ）

Toolkitを活用した下記の3種類のサンプルアプリプロジェクトを提供しています。<br>
下記リポジトリよりご利用ください。

- [Urban Scape](https://github.com/Project-PLATEAU/PLATEAU-Toolkits-Sample-UrbanScape)
- [City Rescue Multiplay](https://github.com/Project-PLATEAU/PLATEAU-Toolkits-Sample-CityRescueMultiPlay)
- [AR Treasure Map](https://github.com/Project-PLATEAU/PLATEAU-Toolkits-Sample-ARTreasureMap)
- [AR City Miniature ※リンク要修正](https://github.com/Project-PLATEAU/PLATEAU-Toolkits-Sample-ARTreasureMap)  
※サンプルシーンを題材とした開発チュートリアルを今後リリース予定です。  

### 更新履歴

|  2024/01/30  |  4th Release <br> Rendering Toolkitにテクスチャ調整機能を追加、SDKのテクスチャ結合機能に対応　<br> PLATEAU Utilitiesを追加 <br> AR Extensionsにテンプレートを追加  <br> サンプルシーン: AR City Miniatureのリリース|  Sandbox Toolkit v1.0.0 <br> Rendering Toolkit v1.0.0 <br> Maps Toolkit v1.0.0 <br> AR Extensions v1.0.0 <br> AR City Miniature v1.0.0 |
| :--- | :--- | :--- |
|  2023/12/25  |  3rd Release <br> Sandbox Toolkitにおけるカメラインタラクション機能、その他調整　　<br>MapsToolkitを別パッケージ化 <br>Rendering Toolkitに頂点カラー機能を追加  <br>AR Extensionsにマーカー位置合わせ機能を追加 <br> サンプルシーン: Urban Scape, City Rescue Multiplay, AR Treasure Mapのリリース|  Sandbox Toolkit v0.3.0（ベータ版） <br> Rendering Toolkit v0.3.0（ベータ版）<br> Maps Toolkit v0.3.0（ベータ版）<br> AR Extensions v0.3.0（ベータ版）<br> Urban Scape v1.0.0 <br> City Rescue Multiplay v1.0.0 <br> AR Treasure Map v1.0.0|
|  2023/10/28  |  2nd Release <br> MapsToolkitのリリース <br> AR Extensionsのリリース <br> Rendering Toolkitにおける雲量調整、ポストエフェクトの追加  |  Maps Toolkit v0.2.1（ベータ版）<br>  AR Extensions v0.2.1（ベータ版） <br> Rendering Toolkit v0.2.1（ベータ版）   |
|  2023/09/15  |  Windows Buildに関する不具合の修正  |  Rendering Toolkit v0.1.1（ベータ版） <br> Sandbox Toolkit v0.1.1（ベータ版）  |
|  2023/07/23  |  1st Release  |  Rendering Toolkit v0.1.0（ベータ版） <br> Sandbox Toolkit v0.1.0（ベータ版）  |



## [Rendering Toolkit](https://github.com/PLATEAU-Toolkits-Internal/PLATEAU-SDK-Toolkits-for-Unity/blob/main/PlateauToolkit.Rendering/README.md)

PLATEAUの3D都市モデルのグラフィックスを向上させる処理を行います。

環境設定、テクスチャの自動作成、LOD設定等の機能をGUI上で提供します。

https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/assets/137732437/85cb8331-bb26-470c-ad69-33c56ffe9143


### リリース済の機能
- 環境システムの設定
- テクスチャ自動生成
- LOD機能
- 雲の量を調整する機能
- ポストエフェクトを追加する機能
- 頂点カラーの設定機能
- テクスチャ調整機能

使い方は[こちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/PlateauToolkit.Rendering)


## [Sandbox Toolkit](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/PlateauToolkit.Sandbox)

PLATEAUの3D都市モデルを用いたゲーム開発、映像製作、シミュレーション実行などを支援します。  
乗り物、人、プロップなどの配置及び操作、トラックの設定機能などをGUI上で提供します。  


https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/assets/137732437/ba417e2b-5621-4f75-95d0-27ce78a1ba5d



### リリース済の機能
- Tracks(道路)の配置機能
- 人物エージェントの配置機能
- 乗り物エージェントの配置機能
- Props(施設器具等)の配置機能
- カメラインタラクション機能
  
使い方は[こちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/PlateauToolkit.Sandbox)


## [PLATEAU SDK-Maps-Toolkit for Unity](https://github.com/Project-PLATEAU/PLATEAU-SDK-Maps-Toolkit-for-Unity)
PLATEAUの3D都市モデルを利用したGIS開発向けツールキットです。Cesium SDK for Unityと連携してPLATEAUの3Dモデルをグローバルな地形モデルに配置することが可能です。また、BIMモデル（IFCファイル）やGISデータ（シェープファイル及びGeoJSON）を読み込んでCesium for Unity上に配置することが可能です。<br>

https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/assets/127069970/5ab8102d-046d-4423-9f7a-7a2029fca630


### リリース済の機能
- Cesium for Unityとの連携
- BIMモデルとの連携（IFCファイルの読み込み）
- GISデータとの連携

[こちらのリポジトリ](https://github.com/Project-PLATEAU/PLATEAU-SDK-Maps-Toolkit-for-Unity)からご利用ください。


## [PLATEAU SDK-AR-Extensions for Unity](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-extensions-for-Unity)
PLATEAUの3D都市モデルを活用したARアプリ開発ツールです。AR空間に3Dモデルを配置し、位置のずれや地面の高さを調整できます。さらに、3Dオブジェクトを遮蔽するオクルージョン機能も備えています。Streamingにより配置された3D都市モデルを用いたARアプリ開発も可能です。
AR ExtensionsはToolkitsを前提としたエクステンションとして構築されています。<br>


https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/assets/127069970/de97d7a9-d6cf-45b6-877a-51bf6259237b

### リリース済の機能


- Geospatial APIを用いた3D都市モデルの位置合わせ機能
- ARマーカーを用いた3D都市モデルの位置合わせ機能
- ARオクルージョン機能

[こちらのリポジトリ](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity)からご利用ください。<br>


## [PLATEAU Utilities ※リンク要修正](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/)

3D都市モデルの選択、高さや位置の調整などの編集の際に役立つ機能を提供します。 


### リリース済の機能
- メッシュレンダラーの選択機能
- メッシュ頂点の平面化機能
- 選択地物の整列機能
- プレハブへのライトマップ設定機能
  
使い方は[こちら ※リンク要修正](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/tree/main/)


# セットアップ環境




## 検証済環境
### 推奨OS環境
- Windows11
- macOS Ventura 13.2

### Unity Version
- Unity 2021.3.30
    - Unity 2021.3系であれば問題なく動作する見込みです。

### Rendering Pipeline
- URP
- HDRP

**Built-in Rendering Pipelineでは動作しません。**

## PLATEAU SDKバージョン
- [PLATEAU SDK for Unity v2.2.1-alpha](https://github.com/Project-PLATEAU/PLATEAU-SDK-for-Unity/releases)

## 導入手順

### 1. Unityでのプロジェクト作成

Unity Version 2021.3.27f1(LTS)により新たにUnityプロジェクトを作成してください。  
その際のテンプレートとして「3D(URP)」もしくは「3D(HDRP)」を選択してください。

<p align="center">
<img width="493" alt="toolkits_setup_select_urp" src="/Documentation~/Images/toolkits_setup_select_urp.png">
</p>


### 2. PLATEAU SDK for Unityのインストール

PLATEAU SDK-Toolkits for Unityを利用するにあたり、事前にPLATEAU SDKのインストールが必要となります。  
TarballかGithub URLからインストールをする必要があります。詳細はPLATEAU SDKのドキュメンテーションをご参照ください。  
[PLATEAU SDK for Unity利用マニュアル](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/)

PLATEAU SDKを利用し、3D都市モデルをUnityシーン上へ配置してください。

### 3. PLATEAU SDK-Toolkits for Unity のインストール

1. Unityエディタを開き、「Window」メニューから「Package Manager」を選択します。
2. 「Package Manager」ウィンドウが開いたら、右上にある「＋」ボタンをクリックします。
3. ドロップダウンメニューから「Add package from tarball...」を選択します。
4. ファイル選択ダイアログが開いたら、インストールしたいパッケージの.tar.gzファイルを探し、選択します。
<p align="center">
<img width="493" alt="toolkits_setup_install_tarball" src="/Documentation~/Images/toolkits_setup_install_tarball.png">
</p>

新しいプロジェクトでPLATEAU SDK-Toolkits for Unityをインストールする際は、入力システムについての確認ダイアログが表示されます場合があります。その場合は「Yes」を選択してください。
Unityエディタが再起動します。

<p align="center">
<img width="500" alt="toolkits_setup_warning" src="/Documentation~/Images/toolkits_setup_warning.png">
</p>

[ダウンロードリンクはこちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/releases/)

## ライセンス
- 本リポジトリはMITライセンスで提供されています。
- 本システムの開発はユニティ・テクノロジーズ・ジャパン株式会社が行っています。
- ソースコードおよび関連ドキュメントの著作権は国土交通省に帰属します。

## 注意事項/利用規約
- 本ツールをアンインストールした場合、本ツールの機能で作成されたアセットの動作に不備が発生する可能性があります。
- 本ツールをアップデートした際は、一度 Unity エディターを再起動することを推奨しています。
- パフォーマンスの観点から、3km²の範囲に収まる3D都市モデルをダウンロード・インポートすることを推奨しています。
- インポートする範囲の広さや地物の種類（建物、道路、災害リスクなど）が量に比例して処理負荷が高くなる可能性があります。
- 本リポジトリの内容は予告なく変更・削除される可能性があります。
- 本リポジトリの利用により生じた損失及び損害等について、国土交通省はいかなる責任も負わないものとします。
