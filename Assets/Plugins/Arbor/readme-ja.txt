-----------------------------------------------------
            Arbor 3: FSM & BT Graph Editor
          Copyright (c) 2014-2018 Cait Sith Ware
          https://caitsithware.com/wordpress/
          support@caitsithware.com
-----------------------------------------------------

Arbor3 Trial版をダウンロードしていただきありがとうございます！

# Trial版の制限

1. DLL

* コアの処理はDLL化しているため編集できません。
* リバースエンジニアリング禁止。

2. ランタイム実行時の制限

* ゲーム開始後2分経過で状態遷移が無効化。
* ゲーム画面に「Arbor3 Trial」の表示。
* (Unityエディタ上でのプレイは制限なくご利用いただけます)

3. ビルドの制限

* IL2CPPビルド利用不可。
* UWPビルド利用不可。

4. Arbor Editorウィンドウ

* Open Asset Storeボタン表示。
* ズーム使用不可。
* グラフキャプチャ使用不可。

# 主な流れ

1. ArborFSMが付いたGameObjectの作成

	作成には以下の方法があります。
	* HierarchyのCreateボタンからArbor/ArborFSMを選択してGameObjectを作成。
	* 既に作成済みのGameObjectがある場合は、InspectorのAdd ComponentボタンからArbor/ArborFSMを選択。

2. Arbor Editorウィンドウを開く

	* ArborFSMのインスペクタにあるOpen Editorボタンをクリック。

3. ステート作成

	* Arbor Editorのグラフ内を右クリックし「ステート作成」を選択。

4. ステートの挙動を追加

	* 作成したステートのヘッダ部を右クリックもしくは歯車アイコンをクリックし、「挙動追加」を選択。
	  表示されたAddBehaviourMenuウィンドウで追加したい挙動を選択。

	  組み込みで追加されている挙動については、以下リファレンスページを参照してください。
	  https://arbor-docs.caitsithware.com/ja/

5. 挙動からの遷移を接続

	遷移接続のためのStateLinkクラスのフィールドを持つ挙動の場合は、ほかステートへの接続できます。
	* StateLinkフィールドをドラッグしほかステート上でドロップして接続。

# サンプルシーン 

サンプルシーンはプロジェクト内の以下のフォルダにあります。
Assets/Plugins/Arbor/Examples/

# ドキュメント

詳しいドキュメントはこちらをご覧ください。
https://arbor.caitsithware.com/

# アセットストア

ご購入はこちら！
https://www.assetstore.unity3d.com/#!/content/112239

# サポート

フォーラム : https://forum-arbor.caitsithware.com/?language=ja

メール : support@caitsithware.com

# リリースノート

Ver 3.4.2:

[修正]

* Arbor Editor

- ArborFSMの配列やListを持つStateBehaviourでNullReferenceExceptionが発生する不具合を修正。

Ver 3.4.1:

[修正]

* ParameterContainer

- Arbor3.3.2以前にObject関連パラメータを追加していた場合、ロード時にエラーが発生してしまう不具合を修正。

* スクリプト

- ParameterConditionが旧フォーマットのまま実行時にシーン読み込みするとNullReferenceExceptionが発生するのを修正。
  [関連する挙動]
    - [StateBehaviour] ParameterTransition
	- [Decorator] ParameterCheck
	- [Decorator] ParameterConditionalLoop
- CalculatorConditionが旧フォーマットのまま実行時にシーン読み込みするとNullReferenceExceptionが発生するのを修正。
  [関連する挙動]
    - [StateBehaviour] CalculatorTransition
	- [Decorator] CalculatorCheck
	- [Decorator] CalculatorConditionalLoop

Ver 3.4.0:

[新機能]

* ノードグラフ内パラメータ

ArborFSMやBehaviourTreeに直接紐づけられるパラメータ機能が追加されました。
サイドパネルの「パラメータ」タブより作成できます。

パラメータのドラッグエリアからグラフビューへドラッグ＆ドロップすることでグラフからパラメータにアクセスできます。

* サブグラフへのデータ受け渡し

SubStateMachineやSubBehaviourTreeなどサブグラフ関連の挙動にグラフ内パラメータへのアクセスフィールドを追加しました。

* ノードのサイズ変更

各種ノードの横幅をドラッグして変更できる機能を追加しました（BehaviourTreeのルートノードなど一部ノードを除く）

* グループノード内の整列

グループノードの中にあるノードの位置やサイズが変更された際に、ノードが重ならないように自動調整する機能を追加しました。

グループノードの設定ウィンドウから「Auto Alignment」を変更して設定できます。

[追加]

* Arbor Editor

- サイドパネルにパラメータタブ追加。
- 各種ノードのサイズ変更追加。
- グループノード内の整列機能追加。

* ParameterContainer

- パラメータのアクセスノードを作成するためのドラッグエリア追加。

* 組み込みStateBehaviour

- GoToTransitionに遷移呼び出しをするメソッド設定を追加。
- ArborFSMを再生開始するPlayStateMachine追加。
- ArborFSMの再生停止するStopStateMachine追加。
- BehaviourTreeを再生開始するPlayBehaviourTree追加。
- BehaviourTreeの再生停止するStopBehaviourTree追加。
- SendMessageGameObject, SendMessageUpwardsGameObject, BroadcastMessageGameObject
    - MethodNameフィールドをFlexibleString型に変更。
    - 引数に使用できる型を追加
        - Long
        - Enum
        - GameObject
        - Vector2
        - Vector3
        - Quaternion
        - Rect
        - Bounds
        - Color
        - Component
        - Slot

* 組み込みActionBehaviour

- ArborFSMを再生開始するPlayStateMachine追加。
- ArborFSMの再生停止するStopStateMachine追加。
- BehaviourTreeを再生開始するPlayBehaviourTree追加。
- BehaviourTreeの再生停止するStopBehaviourTree追加。

* スクリプト

- ParameterContainerにEnum型パラメータへのアクセスメソッド追加。

[改善]

* Arbor Editor

- StateLinkの接続線の開始位置を調整。
- エディタのパフォーマンスを改善。
- StateBehaviourなどのスクリプト選択ウィンドウの検索ワードをスクリプトの種類ごとにキャッシュするように改善。
- 実行中にデータが格納されていないデータ接続線は暗く表示するように改善。

* ParameterContainer

- 各パラメータに全種のデータフィールドを持っていたのを、必要最低限のデータのみ扱うように改善。

* スクリプト

- ParameterConditionの各要素に全種のデータフィールドを持っていたのを、必要最低限のデータのみ扱うように改善。
  [関連する挙動]
    - [StateBehaviour] ParameterTransition
	- [Decorator] ParameterCheck
	- [Decorator] ParameterConditionalLoop
- CalculatorConditionの各要素に全種のデータフィールドを持っていたのを、必要最低限のデータのみ扱うように改善。
  [関連する挙動]
    - [StateBehaviour] CalculatorTransition
	- [Decorator] CalculatorCheck
	- [Decorator] CalculatorConditionalLoop

[修正]

* Arbor Editor

- 挙動を折りたたんだ状態でのデータの接続線の接続位置を修正。
- BehaviourTreeの各ノードの接続スロットをドラッグしてノードを作成した時のノードの作成位置を修正。
- データスロットのラベルがない場合に、ArborEditorウィンドウ以外で使用できない際のヘルプボックスが一段下に表示されていたのを修正。
- Random.SelectComponentなどで使用しているWeightListの各要素を削除するとログが出力されるのを修正。
- ライブ追跡オンの状態でプレイ開始するとNullReferenceExceptionが発生することがある問題を修正。
- FlexibleFieldの参照タイプのDataSlotがCalculatorと表示されてしまうのを修正。
- FlexibleFieldの参照タイプをDataSlotに選択し直すと接続が切れてしまうのを修正。

* スクリプト

- データの入力スロットがリルートノードにのみ接続されているだけで、出力スロットとつながっていない場合にNullReferenceExceptionが発生するのを修正。

* Unity対応

- Unity2018.3.0f1対応
- Unity2019.1.0a10対応

* "Odin - Inspector and Serializer" 対応

- 一部PropertyDrawerが正常に動作していなかったのを対処。

注釈: 
  他アセットとの連携は原則動作保証外です。
  この対処によって問題が発生しなくなるのを保証するものではありません。

Ver 3.3.2:

[変更]

* Arbor Editor

- ノードヘッダーのアイコンボタンにボタンスタイルを使用するように変更。
- StateLinkが接続されている時、歯車アイコンが見えやすいように背景スタイルを変更。

[修正]

* Arbor Editor

- Unity 2019.1.0a5に対応。

* Build

- Universal Windows Platformへビルドするときにエラーが発生するのを修正。

Ver 3.3.1:

[修正]

* Arbor Editor

- ドッキングしたArborEditorウィンドウの最大化を解除すると、データスロットのフィールドにエラーボックスが表示されてしまう不具合を修正。
- Unity2017.3.0以降でサイドパネルとグラフビューの境界線が表示されない時がある不具合を修正。

* ArborFSM

- TransitionTiming.LateUpdateDontOverwriteによる遷移で予約上書きできなかったStateLinkの遷移カウントが増加してしまう不具合を修正。
- TransitionTiming.Immediateで遷移したStateLinkの遷移カウントが増えない不具合を修正。

Ver 3.3.0:

[新機能 : InvokeMethod]

Componentのメソッドを呼び出す組み込みスクリプトを追加。
引数をデータフローから入力したり、戻り値やout引数をデータフローに出力できる。

* 組み込みStateBehaviour

- InvokeMethod追加。

* スクリプト

- ArborEventクラス追加（メソッド呼び出しを行うコアクラス）
- ShowEventAttributeクラス追加（引数がFlexibleに対応していないメソッドの場合でも選択可能する属性）
- HideEventAttributeクラス追加（ArborEventで選択できないように隠す属性）

[新機能 : ObjectPool]

Arbor内でInstantiateしたオブジェクトを使いまわす機能を追加。

* 組み込みStateBehaviour

- 事前Poolingを行うAdvancedPooling追加。
- ObjectPoolからインスタンス化するUsePoolフラグ追加。
    - InstantiateGameObject
	- SubStateMachineReference
	- SubBehaviourTreeReference
- Destroy時にObjectPoolへ返却するように変更。
  (ObjectPoolからInstantiateしている場合のみPoolに戻す)
	- DestroyGameObject
	- OnCollisionEnterDestroy
	- OnCollisionExitDestroy
	- OnTriggerEnterDestroy
	- OnTriggerExitDestroy
	- OnCollisionEnter2DDestroy
	- OnCollisionExit2DDestroy
	- OnTriggerEnter2DDestroy
	- OnTriggerExit2DDestroy

* 組み込みActionBehaviour

- 事前Poolingを行うAdvancedPooling追加。
- 組み込みスクリプトによるInstantiateをObjectPoolに対応。
    - InstantiateGameObject
	- SubStateMachineReference
	- SubBehaviourTreeReference
- 組み込みスクリプトによるDestroyをObjectPoolに対応。
  (ObjectPoolからInstantiateしている場合はPoolに戻す)
    - DestroyGameObject

* スクリプト

- ObjectPooling名前空間にObjectPoolクラス追加。

[追加]

* Arbor Editor

- データスロットのリルートノードの右クリックメニューに「削除（接続を保持）」を追加。
- StateLinkリルートノードの右クリックメニューに「削除（接続を保持）」を追加。
- データスロットの右クリックメニューに「切断」を追加。（出力スロットの場合は「全て切断」）
- NodeBehaviourのInspector拡張スクリプトがある場合、メニューに「Editorスクリプト編集」を追加。
- ツールバーのデバッグメニューに「常にすべてのデータ値を表示」チェックを追加。

* ArborFSM

- 無限ループのデバッグ設定追加。

* BehaviourTree

- 無限ループのデバッグ設定追加。

* ParameterContainer

- enum型追加。

* 組み込みStateBehaviour

- CalcParameterのenum型対応追加。
- ParameterTransitionのenum型対応追加。
- SubStateMachineのメニューに「プレハブに保存」を追加。
- SubBehavioutTreeのメニューに「プレハブに保存」を追加。

* 組み込みActionBehaviour

- SubStateMachineのメニューに「プレハブに保存」を追加。
- SubBehavioutTreeのメニューに「プレハブに保存」を追加。

* 組み込みDecorator

- ParameterCheckのenum型対応追加。
- ParameterConditionLoopのenum型対応追加。

* エディタ拡張

- 自作スクリプト用言語ファイルの設置場所を指定するLanguagePathアセット追加。

* スクリプト

- OutputSlotTypableクラス追加。
- InputSlotTypableクラス追加。
- FlexibleEnumAnyクラス追加(enumを扱えるFlexibleField系クラス）
- ArborFSMInternalクラス
    - 遷移前ステートを参照できるprevTransitionStateプロパティ追加。
    - 遷移後ステートを参照できるnextTransitionStateプロパティ追加。
- StateBehaviourクラス
    - 遷移前ステートを参照できるprevTransitionStateプロパティ追加。
    - 遷移後ステートを参照できるnextTransitionStateプロパティ追加。
    - StateLinkの数を返すstateLinkCountプロパティ追加。
    - StateLinkを返すGetStateLinkメソッド追加。
    - StateLinkのキャッシュを再構築するRebuildStateLinkCacheメソッド追加。
- DataSlotクラスにDisconnectメソッド追加。
- AddBehaviourMenuの多言語対応追加。
- BehaviourTitleの多言語対応追加。
- BehaviourMenuItemの多言語対応追加。

[変更]

* Arbor Editor

- ノードのメインコンテンツGUIをクリックしたときにノードが選択されないように変更。
- データスロットのGUIスタイル変更。
- データスロットのリルートノードをマウスオーバーした時に型名をツールチップに表示するように変更。
- StateLinkリルートノードの右クリックがスロット枠とノード枠で別扱いだったのを統合。
- StateLinkをドラッグ中、そのStateLinkにマウスオーバーしている場合は自ステートに接続しないように変更。
- BehaviourTreeのNodeLinkSlotのGUIスタイル変更。
- デコレータの現在のコンディションを表示するように変更。
- 挙動挿入ボタンを押した時の挙動選択ポップアップの表示位置を調整
- 接続線をマウスオーバーした時に前面表示するように変更。
- 型指定ポップアップでNoneを指定できるように変更。
- 型指定ポップアップウィンドウを方向キーで選択変更できるように対応。
- ParameterReferenceで参照するParameterContainerをデータスロットからも指定できるように変更。
- その他の型のデータの接続線の色を調整。

* BehaviourTree

- ノードアクティブ時にDecoratorが失敗を返した場合はActionBehaviourやServiceのOnStart()は呼び出さないように変更。

* 組み込みStateBehaviour

- InstantiateGameObjectのPrefabをFlexibleComponentに変更。
- SubStateMachineReferenceのExternal FSMをFlexibleComponentに変更。
- SubBehaviourTreeReferenceのExternal BTをFlexibleComponentに変更。

* 組み込みActionBehaviour

- InstantiateGameObjectのPrefabをFlexibleComponentに変更。
- SubStateMachineReferenceのExternal FSMをFlexibleComponentに変更。
- SubBehaviourTreeReferenceのExternal BTをFlexibleComponentに変更。

[最適化]

* Arbor Editor

- Reflectionを使用していたところをdelegateを介すようにして高速化。

* ArborFSM

- StateLinkを事前にキャッシュするように変更。

* スクリプト

- EachFieldクラスを使用した際にフィールドをキャッシュして高速化。
- EachFieldクラスでReflectionを使用していたところをdelegateを介すようにして高速化(AOTやIL2CPP環境では変更なし)。

[廃止]

* スクリプト

- ArborFSMInternalのnextStateプロパティを廃止。
  (代わりにreserverdStateを追加)
- ClassTypeReferenceのTidyAssemblyTypeNameメソッドを廃止。
　(代わりにTypeUtility.TidyAssemblyTypeNameを追加)
- ClassTypeReferenceのGetAssemblyTypeメソッドを配置。
  (代わりにTypeUtility.GetAssemblyTypeを追加)

[修正]

* Arbor Editor

- SubStateMachineReferenceやSubBehaviourTreeReferenceでインスタンス化したグラフをHierarchyで選択した場合にArbor Editorの選択も切り替わるように修正。
- Arbor.StateLinkとは別のStateLinkという名前のクラスがあった場合、エディタ表示で例外が発生していたのを修正。
- データスロットのリルートノード挿入をUndoすると接続が切れてしまっていたのを修正。
- ドラッグ中の接続線の描画がRepaintイベント以外でも行われていたのを修正。

* ArborFSM

- OnStateBegin()内で同グラフのStop()を呼び出した場合の不具合
	- 例外が発生していたのを修正。
    - OnStateEnd()と次回実行時のOnStateBegin()が呼び出されなくなるのを修正。
	- 同ステートの次以降のOnStateBegin()が呼び出されていたのを修正。
- SubStateMachineReferenceでインスタンス化されている場合に、編集すると問題のある項目をInspectorに表示しないように修正。
- Inspectorにて「Copy Component」を行った際、SubStateMachineなどによる子グラフで使用しているNodeBehaviourが余分にコピーされてしまうのを修正。

* BehaviourTree

- SubBehaviourTreeReferenceでインスタンス化されている場合に、編集すると問題のある項目をInspectorに表示しないように修正。
- Inspectorにて「Copy Component」を行った際、SubStateMachineなどによる子グラフで使用しているNodeBehaviourが余分にコピーされてしまうのを修正。

* Waypoint

- Transformを指定していないPointsの要素を削除すると、次の要素まで削除されてしまうのを修正。

* スクリプト

- EachField.Findにターゲットの配列を渡した時に取得できないのを修正。
- EachField.Findにターゲットのインスタンスを渡した時は中身を走査しないように修正。
- WeightList<T>の要素の型をUnityオブジェクトにした場合、オブジェクトを指定しない要素を削除しようとすると次の要素まで削除されてしまうのを修正。

* その他

- Unity2018.3.0b3に対応。

Ver 3.2.4:

[修正]

* Arbor Editor

- Unity2017.3以降で、ノードコメントの文字列をコピーしようとすると例外が発生するのを修正。
- Unity2018.1以降で、ノード内TextFieldの右クリックメニューによるコピーなどが動かないのを修正。
- MacOSのUnity2017.3以降で、挙動のドラッグ＆ドロップをすると自動スクロール判定が残り続けるのを修正。
- ズームアウト時の挙動挿入ボタンの表示位置が若干ずれていたのを修正。 
- リルートノードの右クリックメニューに無駄なセパレータが表示されているのを修正。

Ver 3.2.3:

[修正]

* Arbor Editor

- Unity2018.1でObsoleteになったメソッドを使用していたのを修正。

* 組み込み挙動

- AgentLookAtPositionのAngularSpeedプロパティが表示されていなかったのを修正。
- AgentLookAtTransformのAngularSpeedプロパティが表示されていなかったのを修正。

Ver 3.2.2:

[修正]

* Arbor Editor

- データのリルートノードの方向変更をアンドゥしても即座に接続線に反映されないのを修正。
- 遷移元ステートが画面外にあるときにステートの移動をアンドゥすると即座に接続線に反映されないのを修正。

* その他

- 他のアセットなどをインポートしていると、HierarchyのCreateボタンにArborグループが表示されない場合があるのを修正。

Ver 3.2.1:

[修正]

* Arbor Editor

- 一度挙動をドラッグした後に、挿入ボタンから挙動追加すると、挿入位置が一つ前になるのを修正。

* ArborFSM

- OnStateUpdate()内でTransitionTiming.Immediateにより遷移した後、同じフレームのLateUpdate()で遷移先ステートの処理がされてしまうのを修正。

* BehaviourTree

- コンポジットノードとアクションノードの共通メニュー項目が抜け落ちていたのを修正。

Ver 3.2.0:

[追加]

* Arbor Editor

- Calculatorの右クリックメニューに「スクリプト編集」追加。
- グループノードの色変更追加。
- 遷移ラインの右クリックメニューに「設定」追加。
- 挙動をInspectorにドラッグ＆ドロップできるように対応。
- 挙動を別ノードにドラッグ＆ドロップできるように対応。
	- Ctrl+ドロップ(Macではoption+ドロップ)でコピー。
- 挙動挿入ボタン追加。
- ノード内の挙動の展開と折りたたみ追加。
	- ノードの右クリックメニュー
	- グラフの右クリックメニュー（選択中ノードが対象）
	- ツールバー(全てのノードが対象)
- プレイ中のアクティブノード追跡
	- ツールバーの「ライブ追跡」トグルで切り替え
- ArborEditorの設定項目追加
	- ドッキングして開く : ArborEditorウィンドウを開いたときにSceneViewとドッキングするか設定
	- マウスホイールの挙動 : ズームするかスクロールするかを設定(Unity 2017.3以降)
	- 階層のライブ追跡 : ライブ追跡をする際、子グラフに自動的に切り替わるか設定
- ドラッグ中にマウスオーバーすると自動スクロールするエリアの表示を追加。

* Behaviour Tree

- コンポジットノードの右クリックメニューに「コンポジット置き換え」追加。
- アクションノードの右クリックメニューに「アクション置き換え」追加。

* Parameter Container

- VariableスクリプトのテンプレートにFlexibleFieldのコンストラクタや型変換追加。

* 組み込み挙動

- Tween系挙動に現在値から指定した値までの変化モードを追加。
  (これに伴い、RelativeフィールドをTweenMoveTypeフィールドに変更)
	- TweenPosition
	- TweenRotation
	- TweenScale
	- TweenRigidbodyPosition
	- TweenRigidbodyRotation
	- TweenRigidbody2DPosition
	- TweenRigidbody2DRotation
	- TweenTextureOffset
	- TweenCanvasGroupAlpha
	- UITweenPosition
	- UITweenSize
- TweenColorSimple追加。
- UITweenColorSimple追加。
- TweenTextureScale追加。
- TweenMaterialFloat追加。
- TweenMaterialVector2追加。
- TweenTimeScale追加。
- TweenBlendShapeWeight追加。

* 組み込み演算ノード

- Random.Value追加。
- Random.InsideUnitCircle追加。
- Random.InsideUnitSphere追加。
- Random.OnUnitSphere追加。
- Random.Rotation追加。
- Random.RotationUniform追加。
- Random.RangeInt追加。
- Random.RangeFloat追加。
- Random.Bool追加。
- Random.RangeVector2追加。
- Random.RangeVector3追加。
- Random.RangeQuaternion追加。
- Random.RangeColor追加。
- Random.RangeColorSimple追加。
- Random.SelectString追加。
- Random.SelectGameObject追加。
- Random.SelectComponent追加。

* 組み込みコンポジット

- RandomExecutor追加。
- RandomSelector追加。
- RandomSequencer追加。

* 組み込みVariable

- Gradient追加。
- AnimationCurve追加。

* スクリプト

- ClassTypeConstraint属性を使用できるクラスを追加。
	- AnyParameterReference
	- ComponentParameterReference
	- InputSlotComponent
	- InputSlotUnityObject
	- InputSlotAny
	- FlexibleComponent
- ClassGenericArgumentAttribute追加。
- ParameterContainerにTryGetIntメソッドなどを追加。
- ParameterContainerにパラメータがない場合のデフォルト値を指定できるGetIntメソッドなどを追加。
- Quaternionをオイラー角で編集できるようにするEulerAnglesAtribute追加。
	- ParameterのQuaternionをEulerAnglesに対応。
	- FlexibleQuaternionをEulerAnglesに対応。
- Variableの追加メニュー名を指定するAddVariableMenu属性追加。
- State.IndexOfBehaviourメソッド追加。
- NodeBehaviourListにIndexOfメソッド追加。
- FlexiblePrimitiveTypeを使うクラスの基本クラスFlexiblePrimitiveBase追加。
- ConstantRangeAttribute追加(Range属性のFlexibleField版)
	- FlexibleInt, FlexibleFloatに対応。
- 各DataSlot固有のフィールドを隠すHideSlotFields属性追加
	- 主にOutputSlotComponent、OutputSlotUnitObjectのTypeフィールドを隠すのに使用する。
- AgentControllerに各フィールドにget/setアクセスするプロパティ追加。
	- agent
	- animator
	- movingParameter
	- movingSpeedThreshold
	- speedParameter
	- isDivAgentSpeed
	- speedDampTime
	- movementType
	- movementDivValue
	- movementXParameter
	- movementXDampTime
	- movementYParameter
	- movementYDampTime
	- movementZParameter
	- movementZDampTime
	- turnParameter
	- turnType
	- turnDampTime
- CompositeBehaviouorに拡張用メソッド追加
	- GetBeginIndex
	- GetNextIndex
	- GetInterruptIndex
- DecoratorにisRevaluationプロパティ追加。

[変更]

* Arbor Editor

- ステートのリルートノードを作成した時、ラインの色を引き継ぐように変更。
- FlexiblePrimitiveType.Randomを使用しているCalculatorは常に再計算するように変更。
- 挙動をドラッグ中に自動スクロールするように変更。

* Parameter Container

- 値のラベルを表示するように変更。

* AgentController

- Animatorを指定しない場合、パラメータ名をTextFieldで編集できるように変更。
	- (AnimatorParameterReferenceも同様に対応)

* 組み込み挙動

- いくつかの組み込み挙動のフィールドをFlexibleFieldに変更。
	- TweenBase : Duration, Curve, UseRealtime, RepeatUntilTransition
	- TweenColor : Gradient
	- TweenTextureOffset : PropertyName
	- UITweenColor : Gradient
	- LoadLevel : LevelName
	- BroadcastTrigger : Message
	- SendTrigger : Target, Message
	- SendTriggerGameObject : Message
	- SendTriggerUpwards : Message
	- TriggerTransition : Message
- Material変更する挙動をMaterialPropertyBlockを使用する様に変更。
	- TweenColor
	- TweenTextureOffset
- Tween系の各フィールドをステート開始時にキャッシュするように変更。

* 組み込み演算ノード

- AddBehaviourMenuとタイトル名が一致するように変更。

* 組み込みデコレータ

- 時間経過プログレスバーを再評価対象の時のみ表示するように変更。
	- Cooldown
	- TimeLimit

* スクリプト

- ComponentParameterReferenceにParameter.Type.Component以外のコンポーネントパラメータを指定できるように変更。
- CalculatorSlotをDataSlotにリネーム。
- CalculatorBranchをDataBranchにリネーム。
- CalculatorBranchRerouteNodeをDataBranchRerouteNodeにリネーム。
- FlexibleType.CalculatorをDataSlotにリネーム。
- FlexiblePrimitiveType.CalculatorをDataSlotにリネーム。
- DataBranch.isVisibleをshowDataValueにリネーム。

[廃止]

* スクリプト

- booとjavascriptのスクリプト作成を廃止。
- InputSlotAny(System.Type)コンストラクタを廃止。
- OutputSlotAny(System.Type)コンストラクタを廃止。
- AnyParameterReference.parameterTypeを廃止。
- AnyParameterReference(System.Type)コンストラクタを廃止。
- ParameterContainerの古いGetIntメソッドなどを廃止。

[修正]

* Arbor Editor

- BehaviourTreeを選択している時、ツールバーのデバッグメニューの一番下にセパレータが表示されていたのを修正。
- データ値表示切替メニューの文言修正。
- abstractの挙動クラスが挙動追加ウィンドウに表示されてしまうのを修正。
- 矩形選択ドラッグ中に自動スクロールした時に、矩形を更新するように修正。

Ver 3.1.3:

[修正]

* Editor

- MonoBehaviourスクリプトにCalculatorSlotを宣言した場合にInspectorを表示すると例外が発生するのを修正。
- シリアライズできない型でFlexibleField<T>を宣言した場合に、フィールド名のラベルが表示されなくなっていたのを修正。

* スクリプト

- InputSlot<T>がスクリプトリファレンスに表示されないのを修正。
	- InputSlotクラスをInputSlotBaseに改名。
- OutputSlot<T>がスクリプトリファレンスに表示されないのを修正。
	- OutputSlotクラスをOutputSlotBaseに改名。
- FlexibleField<T>にSerializable属性のついたクラスしか使用できなかったのを修正。
- Variable<T>にSerializable属性のついたクラスしか使用できなかったのを修正。
- Variable<T>にシリアライズ可能な型を指定しても"not serializable"になっていたのを修正。
- AddComponentメニューに表示されないようにArborスクリプトテンプレートを修正。
- Exmaple用スクリプトのAddComponentメニューの表示位置を"Arbor/Example"に修正。
- CalculatorSlotのフィールドにSlotTypeAttributeでサブクラス以外の型を指定した場合に無視するように修正。
- SlotTypeAttributeを使用できるCalculatorSlotを以下のクラスに制限するように修正。
	InputSlotComponent、InputSlotUnityObject、InputSlotAny、OutputSlotAny

Ver 3.1.2:

[修正]

* Arbor Editor

- System.Serializable属性をつけたUnityオブジェクト派生クラスが自身を参照するフィールドを持っている時に無限再帰してしまうのを修正。

Ver 3.1.1:

[追加]

* 組み込みStateBehaviour

- AgentWarpToPosition追加
- AgentWarpToTransform追加
- TransformSetPosition追加
- TransformSetRotation追加
- TransformSetScale追加
- TransformTranslate追加
- TransformRotate追加

* 組み込みActionBehaviour

- AgentWarpToPosition追加
- AgentWarpToTransform追加

* 組み込みCalculator

* StringConcatCalculator追加
* StringJoinCalculator追加

* スクリプト

- AgentControllerにWarpメソッド追加。
- NodeBehaviourにOnGraphPause,OnGraphResume,OnGraphStopコールバック追加。

[修正]

* ArborFSM

- Stateコールバックメソッド以外でTransitionTiming.Immediateの遷移を行うと遷移回数が増えない問題を修正。
- ArborFSM.Stop()を呼び出した時に、OnStateEndメソッドがコールバックされないのを修正。

- BehaviourTree

- BehaviourTree.Stop()を呼び出した時に、OnEndメソッドがコールバックされないのを修正。

* 組み込みStateBehaviour

- Tween系のDurationを0にすると完了時の遷移が行われないのを修正。

Ver 3.1.0:

[追加]

* ArborEditor

- グラフ未選択のときにグラフ作成ボタンやマニュアルページを開くボタンなどを表示。
- グラフのズーム機能を追加(Unity 2017.3.0f3以降のみ有効)
- グラフのキャプチャ機能を追加。
- ツールバーにグラフ作成ボタン追加。
- ArborEditorでグラフを開いた時にArborロゴの表示を追加。
	歯車アイコンをクリックして表示される設定ウィンドウでトグルできます。
- AssetStoreの更新通知を追加。

* ArborEditor拡張

- ArborEditorWindowクラスに、背面をカスタマイズできるunderlayGUIコールバック追加。
- ArborEditorWindowクラスに、前面をカスタマイズできるoverlayGUIコールバック追加。
- ArborEditorWindowクラスに、ツールバーをカスタマイズできるtoolbarGUIコールバック追加。

* ParameterContainer

- ユーザー定義型を追加できるVariable追加。
- Variable定義のスクリプトをテンプレートから作成するVariableGeneratorWindow追加。

* AgentController

- MovementTypeフィールド追加。
- MovementDivValueフィールド追加。
- TurnTypeフィールド追加。
- 移動値や回転量をMovementTypeとTurnTypeに従ってAnimatorへ受け渡すように変更。

* 組み込みStateBehaviour

- AgentControllerを指定位置方向に向き直すAgentLookAtPosition追加。
- AgentControllerを指定Transform方向に向き直すAgentLookAtTransform追加。
- プレハブのArborFSMを子グラフとして実行するSubStateMachineReference追加。
- プレハブのBehaviourTreeを子グラフとして実行するSubBehaviourTreeReference追加。
- シーンをアクティブにするSetActiveScene追加。
- LoadLevelにIsActiveSceneフィールドを追加。
- LoadLevelにDone遷移追加。

* 組み込みActionBehaviour

- AgentControllerを指定位置方向に向き直すAgentLookAtPosition追加。
- AgentControllerを指定Transform方向に向き直すAgentLookAtTransform追加。
- プレハブのArborFSMを子グラフとして実行するSubStateMachineReference追加。
- プレハブのBehaviourTreeを子グラフとして実行するSubBehaviourTreeReference追加。
- Waitに経過時間の表示を追加。

* 組み込みDecorator

- TimeLimitに経過時間の表示を追加。
- Cooldownに経過時間の表示を追加。

* スクリプト

- Assembly Definitionに対応（Unity2017.3.0f3以降のみ有効）
	この対応に伴い、フォルダ構成も変更。
- NodeGraphクラスにrootGraphプロパティ追加。
- NodeGraphクラスにToStringメソッド追加。
- NodeクラスにGetNameメソッド追加。
- NodeクラスにToStringメソッド追加。
- 入力する型を指定できるInputSlotAnyクラス追加。
- 出力する型を指定できるOutputSlotAnyクラス追加。
- 参照するパラメータの型を指定できるAnyParameterReferenceクラス追加。
- Flexibleな型クラスのジェネリッククラス版FlexibleField<T>追加。
- ParameterにvariableValueプロパティ追加。
- ParameterにSetVariableメソッド追加。
- ParameterにGetVariableメソッド追加。

[変更]

* ArborEditor

- Gridボタンを歯車アイコンに変更し、ボタンを押して表示されるポップアップウィンドウをグリッド以外も設定するGraphSettingsウィンドウに改名。
- ツールバーの言語ポップアップをGraphSettingsウィンドウへ移動。
- ツールバーのヘルプボタンからアセットストアやマニュアルページを開くメニューを表示するように変更。
- 接続線をマウスオーバーした時のハイライト表示を見やすいデザインに変更。
- グループノードのリサイズを各辺のドラッグでできるように変更。
- サイドパネルのノードリストでCtrlやShiftを押しながら複数選択できるように変更。
- リルートノードの向きをドラッグ中にEscキーを押すとキャンセルできるように変更。

* 組み込みStateBehaviour

- LoadLevelのAdditiveフィールドをLoadSceneModeフィールドに変更。
- TimeTransitionのSecondsフィールドをFlexibleFloat型に変更。

* スクリプト

- FlexibleField関係のクラスで使用する参照タイプを共通で使用するように変更。
- Parameter.intValueなどをプロパティ化。
	setした際にonChangedを呼ぶように変更。
- Parameter.valueプロパティにset追加。

[廃止]  

* スクリプト

- Parameter.OnChangedをObsoleteに変更。
	Parameter.intValueなどを変更した際に内部でonChangedがコールバックされるようになったため、呼び出しは不要になりました。
- AddCalculatorMenu属性をObsoleteに変更。
	AddBehaviourMenu属性を共通で使用するように変更しました。
- BuiltInCalculator属性をObsoleteに変更。
	BuiltInBehaviour属性を共通で使用するように変更しました。
	また、BuiltInBehaviour属性は組み込み挙動用の属性のため、それ以外では使用しなくても問題ありません。
- CalculatorHelp属性をObsoleteに変更。
	BehaviourHelp属性を共通で使用するように変更しました。
- CalculatorTitle属性をObsoleteに変更。
	BehaviourTitle属性を共通で使用するように変更しました。

[修正]

* ArborEditor

- BehaviourTreeが実行終了してもArborEditor上ではアクティブ表示されたままとなり、まるで実行が継続されているように見えていたのを修正。
- FlexibleGameObjectのCalculatorタイプフィールドの高さを修正。
- サイドパネルのグラフ名入力欄が入力欄以外をクリックしてもフォーカスしたままになっているのを修正。
- StateLinkやCalculatorSlotなどの接続線のドラッグ中にEscキーを押すとドラッグ中のライン表示が残ってしまうのを修正。
- サイドパネルのヘッダスタイルがUnityのバージョンにより見た目が変わっていたのを修正。
- ConstantMultilineAttributeをつけたFlexibleStringでテキストの切り取りや貼り付けなどの編集ができなかったのを修正。
- ドッキングされているArborEditorウィンドウが非表示のままプレイ開始やシーン切り替えなどをするとNullReferenceExceptionが発生するのを修正。
- プレイモード終了時に画面外のノードへの接続線の表示位置が正しくない不具合を修正。
- Actionノードをコピーするときノード名がコピーされていなかったのを修正。
- Compositeノードをコピーするときノード名がコピーされていなかったのを修正。
- ノードを貼り付けや複製した時にグリッドスナップが効いていなかったのを修正。
- Stateの遷移元がリルートノードの場合に、Stateを削除しても接続ラインが消えなかったのを修正。
- StateLinkを接続しているStateを削除後にリドゥすると、接続ラインがすぐに再描画されないのを修正。
- ノード選択のUndo/Redoを修正。
- ノード作成や削除のUndo/Redoを繰り返し行うとメモリリークしていたのを修正。
- グラフ選択のUndo/Redoをしたときの不具合を修正。
- ノード選択していない場合はFrame Selectedできないように修正。

* ArborFSM

- Unity2018.1以降でArborFSMのRemoveComponentを行うとNullReferenceExceptionが発生するのを修正。
- プレハブのArborFSMをシーンウィンドウにドラッグ＆ドロップすると、グラフ内部で使用しているコンポーネントがインスペクタに表示されてしまうのを修正。

* BehaviourTree

- 現在ノードがRootになったタイミングで割り込み判定が行われるとNullReferenceExceptionが発生するのを修正。
- Unity2018.1以降でBehaviourTreeのRemoveComponentを行うとNullReferenceExceptionが発生するのを修正。
- プレハブのBehaviourTreeをシーンウィンドウにドラッグ＆ドロップすると、グラフ内部で使用しているコンポーネントがインスペクタに表示されてしまうのを修正。

* AgentController

- AgentController自身のTransformを参照していた不具合を修正。
- AgentControllerの初期化をAwakeで行うように修正。

* 組み込みStateBehaviour

- SubStateMachineのUpdateTypeをManualに修正
	ルートグラフのUpdateTypeにより適切なタイミングで処理されるように変更。
- SubBehaviourTreeを追加するとArborFSMがインスペクタに表示されなくなるのを修正。

* 組み込みActionBehaviour

- WaitのSecondsが毎フレーム再計算していたのを修正。

* 組み込みDecorator

- TimeLimitのSecondsが毎フレーム再計算していたのを修正。
- CooldownのSecondsが毎フレーム再計算していたのを修正。

* スクリプト

- State.transitionCountをuintに修正。
- State.transitionCountがuint.MaxValueを超えないように修正。
- StateLink.transitionCountをuintに修正。
- StateLink.transitionCountがuint.MaxValueを超えないように修正。

* その他

- スクリプトのコンパイル直後にプレイ開始すると、開始までに時間がかかるようになっていたのを修正。
- Unity2018.2.0 ベータ版でのエラー修正。

Ver 3.0.2:

[追加]

* 組み込みStateBehaviour

- AddForceRigidbodyにForceModeとSpaceのフィールド追加。
- AddVelocityRigidbodyにSpaceのフィールド追加。
- SetVelocityRigidbodyにSpaceのフィールド追加。
- AddForceRigidbody2DにForceModeとSpaceのフィールド追加。
- AddVelocityRigidbody2DにSpaceのフィールド追加。
- SetVelocityRigidbody2DにSpaceのフィールド追加。
- AgentMoveOnWaypointにStoppingDistance追加。

* 組み込みActionBehaviour

- AgentMoveOnWaypointにStoppingDistance追加。

[修正]

* ArborEditor

- 演算スロットのドラッグ中に、継承の関係にあり接続可能なスロットがハイライト表示されていなかったのを修正。

* コンポーネント

- AgentControllorのisDoneがfloatの計算誤差によりtrueにならないことがあったのを修正。

* 組み込みStateBehaviour

- SubStateMachineのUpdateTypeをManualに修正。

Ver 3.0.1:

[修正]

* Arbor Editor

- Arbor Editorウィンドウを閉じた後にノードグラフを削除すると例外が発生するのを修正。
- Arbor Editorウィンドウをドッキングしていない状態でアクションノードやコンポジットノードを作成するとリネーム枠が表示されなかったのを修正。
- 読み込みに失敗したDLLが存在しているとArborEditorでもエラーが発生してしまうのを修正。

* 組み込みActionBehaviour

- DestroyGameObjectのリファレンスがなかったのを修正。

Ver 3.0.0:

[新機能：Behaviour Tree]

* 概要

新機能として、木構造により優先順位を見える化しながら挙動を組めるBehaviour Treeを追加しました。

最初にアクティブになるRootNodeや、子ノードの実行順などを決めるCompositeNodeと行動を指定するActionNodeがあります。

ActionNodeには挙動を記述するためのスクリプトActionBehaviourを設定できます。
ActionBehaviourも、ArborFSMのStateBehaviourと同様にカスタマイズ可能です。

CompositeNodeとActionNodeには実行する条件チェックや繰り返しなどを行うスクリプトDecoratorも追加できます。
こちらもカスタマイズが可能です。

他にも、ノードがアクティブな間実行されるServiceスクリプトにより柔軟なAIが作成可能となっております。

また、ArborFSMと同様に演算ノードと演算スロットを活用することでノード間のデータの受け渡しもできます。

* コンポーネント
- BehaviourTreeコンポーネント追加。

* 組み込みCompositeBehaviour
- Selector追加。
- Sequencer追加。

* 組み込みActionBehaviour
- Wait追加。
- PlaySound追加。
- PlaySoundAtPoint追加。
- PlaySoundAtTransform追加。
- StopSound追加。
- SubStateMachine追加。
- SubBehaviourTree追加。
- InstantiateGameObject追加。
- DestroyGameObject追加。
- ActivateGameObject追加。
- AgentPatrol追加。
- AgentMoveToPosition追加。
- AgentMoveToTransform追加。
- AgentMoveOnWaypoint追加。
- AgentEscapeFromPosition追加。
- AgentEspaceFromTransform追加。
- AgentStop追加。

* 組み込みDecorator
- Loop追加。
- SetResult追加。
- InvertResult追加。
- ParameterCheck追加。
- CalculatorCheck追加。
- ParameterConditionalLoop追加。
- CalculatorConditionLoop追加。
- TimeLimit追加。
- Cooldown追加。

* Script
- 子ノードの実行を制御するCompositeBehaviour追加。
- アクションを実行するActionBehaviour追加。	
- ノードを装飾するDecorator追加。
- ノードがアクティブの間実行するService追加。

[追加]

* Arbor Editor
- グラフの階層化に対応。
- サイドパネルにGraph項目追加。
- StateLinkのドラッグ中に何もないところでドロップした場合のメニュー追加。
- StateLink接続ラインのリルートノード追加。
- CalculatorBranch接続ラインのリルートノード追加。
- CalculatorBranchの値をクリックするとConsoleにログ出力するように追加。
- Alt(MacではOption)キーを押しながらグループノードを移動すると、グループ内のノードは移動しない機能を追加。

* ArborFSM
- 開始時に再生するフラグPlay On Startフィールド追加。
- 更新間隔などの設定を行うUpdate Settingsフィールド追加。

* ParameterContainer
- Componentパラメータの型指定を追加。
- Colorパラメータ追加。

* 組み込みStateBehaviour
- SubStateMachine追加。
- EndStateMachine追加。
- SubBehaviourTree追加。
- AgentPatrolにCenter Typeフィールド追加。
- AgentPatrolにCenter Transformフィールド追加。
- AgentPatrolにCenter Positionフィールド追加。
- RaycastTransitionにIs Check Tagフィールド追加。
- RaycastTransitionにTagフィールド追加。

* Script
- グラフを扱うための基本クラスNodeGraph追加。
- NodeがNodeBehaviourを格納する場合に使用するインターフェイスINodeBehaviourContainer追加。
- NodeBehaviourが子グラフを格納する場合に使用するインターフェイスINodeGraphContainer追加。
- NodeBehaviour作成時に呼ばれるOnCreatedメソッド追加。
- NodeBehaviour破棄前に呼ばれるOnPreDestroyメソッド追加。
- ArborFSMInternalにPlayとStopメソッド追加。
- ArborFSMInternalにPauseとResumeメソッド追加。
- ArborFSMInternalにplayStateプロパティ追加。
- TimeTypeから現在時間を返すTimeUtility.CurrentTimeメソッド追加。
- Bezier2DにGetClosestParamメソッド追加。
- Bezier2DにGetClosestPointメソッド追加。
- Bezier2DにSetStartPointメソッド追加。
- Bezier2DにSetEndPointメソッド追加。
- ComponentParameterReferenceで参照するComponentの型をSlotTypeAttributeで指定できるように追加。

[変更]

* Arbor Editor
- ツールバーのステートリストをサイドパネルに改名。
- サイドパネルのステートリストをノードリストに改名。
- ステートをコピー＆ペーストした際に、コピー元とコピー先が同じArborFSMだった場合にStateLinkを接続したままペーストするように変更。
- ステートをコピー＆ペーストした際に、StateLinkの接続先ステートもペーストされたノードならStateLinkを接続したままにするように変更。
- StateLinkのラインのマウスオーバー時に色を変更。
- StateBehaviourのタイトルバーを右クリックしたときにもメニューが表示されるように変更。
- 実行中にCalculatorBranchの値を表示する方法を、ラインをマウスオーバーするか右クリックメニューから「値を常に表示する」にチェックする方法に変更。
- 実行中の現在ステートのデザインを変更。
- 選択中ノードへの移動スクロールを調整。

* 組み込みStateBehaviour
- AgentMoveOnWaypoint開始時に現在目標地点への移動を行い、移動完了後に目標地点を次に移すように変更。

* Script
- ArborFSMInternalをNodeGraphから継承するように変更。
- ArborFSMInternalのfsmNameを削除（NodeGraphにgraphNameを使用すること）。
- ArborFSMのFindFSMとFindFSMsをObsoleteに変更（NodeGraphのFindGraphとFindGraphsを使用すること)。
- StateBehaviourのstateIDをObsoleteに変更（nodeIDを使用すること）。
- NodeとNodeBehaviourから参照するグラフをArborFSMInternalからNodeGraphに変更。
- CalculatorNodeをNodeGraphで管理するように変更。
- GroupNodeをNodeGraphで管理するように変更。
- CommentNodeをNodeGraphで管理するように変更。
- ClaculatorBranchをNodeGraphで管理するように変更。
- CalculatorSlotのstateMachineフィールドをnodeGraphフィールドに変更。
- NodeBehaviourのstateMachineプロパティをStateBehaviourに移動。
- StateLinkのlineEnableをNonSerializedに変更。
- StateLinkのlineStartなどを削除しbezierフィールドを追加。
- TimeTransitionクラス内のTimeTypeをArbor名前空間に移動。
- 組み込みStateBehaviourの名前空間をArbor.StateMachine.StateBehavioursに変更。
- FlexibleComponentで指定したSlotTypeAttributeで参照するParameterを指定するように変更。
- 再描画が必要な時にEditorクラスのRequiresContentRepaintメソッドを使用できるように変更。

* その他
- NodeGraphをInspectorからHierarchyにドラッグして移動できないように変更。
- 組み込みNodeBehaviour関連スクリプトをBuiltInBehavioursフォルダに移動。

[修正]

* Arbor Editor
- ノードをコピーした後にArborFSMのCopy Componentを行うとノードのコピーが消えるのを修正。
- TransitionTiming.Immediateによる遷移を繰り返すとStackOverflowExceptionが発生していたのを修正。
- ステートにブレークポイントが設定されていてもTransitionTiming.Immediateによって遷移したい場合に停止しなかったのを修正。
- AddBehaviourMenuウィンドウとAddCalculatorMenuウィンドウ内の階層アニメーション中に検索ワードを入力すると例外が発生するのを修正。
- NodeGraphのRemove ComponentをUndoした場合にArbor Editorの参照が戻らないのを修正。
- ノード内を右クリックしたときにグラフのメニューが表示されないように修正。
- 実行中にStateBehaviourのbehaviourEnabledを切り替えた場合にOnStateAwakeとOnStateBeginが呼ばれるように修正。
- 実行中にStateBehaviourを追加した場合にOnStateAwakeとOnStateBeginが呼ばれるように修正。
- Unityを起動した際にTypePopupWindowで"Removed unparented EditorWindow while reading window layout"のログが出るのを修正。
- 実行中に常に再描画していたのを必要な時のみ行うように修正。
- ノード作成時にグリッドスナップするように修正。
- ノード作成などでグラフ領域のサイズが変更されたときにノードの表示がボケるのを修正。

* Script
- EachFieldで基本クラスのpublicとprotectedフィールドを重複して列挙していたのを修正。

* その他
- InspectorからResetを行うとNodeBehaviourが内部的に残ったままになるのを修正。
- ArborFSMコンポーネントを削除した時にCalculatorが内部的に残ったままになるのを修正。

Ver 2.2.3:

* Arbor Editor
- Fix : ノードのリネーム中にノードのショートカットが使えていたのを修正。
- Fix : ParameterContainerのパラメータの順番を変更するとそのパラメータを参照していると発生する例外を修正。

Ver 2.2.2:

* Arbor Editor
- Add : 削除したStateBehaviourやCalculatorのスクリプトを使用しているノードやオブジェクトを削除できるように追加。
- Fix : ArborFSMで使用しているStateBehaviourやCalculatorのスクリプトを削除するとArbor Editorウィンドウで例外(ArgumentNullException)が発生するのを修正。

* その他
- Change : Unity最低動作バージョンを5.4.0f3に引き上げ。

Ver 2.2.1:

* Arbor Editor
- Change : FlexibleStringのConstant時の表示を差し戻し。
- Fix : Arbor Editorを開いた状態でUnityエディタ上でのプレイ終了すると例外(NullReferenceException: SerializedObject of SerializedProperty has been Disposed.)が発生するのを修正。
- Fix : 言語を切り替えてもGraphのラベルが変わらないのを修正。

* コンポーネント
- Add : ParameterContainerで使用できるパラメータにLong追加。
- Change : ParameterContainerでパラメータを並び替えできるように変更。
- Change : ParameterContainerにパラメータの型を表示。

* 組み込みCalculator
- Add : LongAddCalculator追加
- Add : LongSubCalculator追加
- Add : LongMulCalculator追加
- Add : LongDivCalculator追加
- Add : LongNegativeCalculator追加
- Add : LongCompareCalculator追加
- Add : LongToFloatCalculator追加
- Add : FloatToLongCalculator追加

* Script
- Add : FlexibleStringのConstant時の表示を複数行にするConstantMultilineAttribute追加。
- Add : long型パラメータの追加に伴い、FlexibleLong、LongParameterReference、InputSlotLong、OutputSlotLong追加。
- Fix : Unityエディタ上でのプレイ開始時に型列挙処理が行われることで負荷がかかっていたのを修正。

Ver 2.2.0:

* Arbor Editor
- Add : グループノード追加。
- Add : 各種ノードごとのコメント追加。
- Add : ノードの切り取りに対応。
- Add : ノードのコンテキストメニューにノードの切り取り、コピー、複製、削除の項目追加。
- Add : StateLinkボタンにTransition Timingアイコン表示。
- Add : ArborFSMインスペクタのCopy Componentで内部コンポーネント含めてコピーできるように対応。
- Change : Editorのデザイン変更。
- Change : ステートの名前入力欄をダブルクリックで表示するように変更。
- Change : ステートリストを種類順(開始ステート -> 通常ステート -> 常駐ステート)にソートするように変更。
- Change : StateLinkSettingWindowのImmediate TransitionをTransition Timingに変更。
- Change : OutputSlotComponentに型指定を追加。
- Change : FlexibleStringのConstant時の表示をTextAreaに変更。
- Change : ドラッグでのスクロール中は一定時間間隔でスクロールされるように対応。
- Change : ドラッグでのスクロール中の最大移動量を調整。
- Fix : ノードをドラッグ中にスクロールするとノードの位置がずれるのを修正
- Fix : CalculatorBranchの線が長い場合に頂点数エラーが出るのを修正
- Fix : StateLinkSettingWindowを画面端で表示すると縦に余白が表示されるのを修正。
- Fix : StateLinkを同じステートに接続し直した時にラインが非表示になってしまうのを修正。
- Fix : 実行中にArborFSMオブジェクトのPrefabにApplyした際にStateBehaviourがインスペクタに表示されてしまうのを修正。
- Fix : 実行中にArborFSMオブジェクトのPrefabにApplyした際に現在ステートのStateBehaviourが有効状態のままPrefabに保存されてしまうのを修正。
- Fix : CalculatorSlotを配列で持っているBehaviourでSizeを変更した際の接続を修正。
- Fix : ノードを削除した時に他のノードが一瞬表示されなくなるのを修正。
- Other : CalculatorBranchのドット線の表示を最適化。

* 組み込み挙動
- Add : AgentStop追加。
- Add : AgentMoveOnWaypoint追加。
- Add : AnimatorCrossFade追加。
- Add : AnimatorSetLayerWeight追加。
- Add : BackToStartState追加。
- Add : ActivateBehaviour追加。
- Add : ActivateRenderer追加。
- Add : ActivateCollider追加。
- Add : UISetSlider、UISetText、UISetToggleにChangeTimingUpdateパラメータ追加。
- Change : LookAtGameObjectにTarget transformの各座標成分を使用するかどうかのフラグ追加。
- Change : Agent系にステートを抜けるときにAgentを止めるかどうかのフラグ追加。
- Change : ドキュメントのUITextFromParameterのformatに形式指定の参考URL追加。
- Change : Componentを参照している組み込み挙動をFlexibleComponentに対応。
- Change : UISetSliderとUISetToggleのFlexibleComponent対応により、UISetSliderFromParameterとUISetToggleFromParameterをLagacyに移動。
- Fix : GlobalParameterContainerを介してParameter変更時に処理している挙動で、シーン遷移後に例外が発生してしまうのを修正(UISetTextFromParameter、UISetToggleFromParameter、UISetSliderFromParameter、ParameterTransition)。
- Fix : UISetImageのリファレンスがなかったのを修正。

* 組み込みCalculator
- Add : GameObjectGetComponentCalculator追加。
- Fix : GlobalParameterContainerを介してParameter変更時に処理しているCalculatorで、シーン遷移後に例外が発生してしまうのを修正。

* コンポーネント
- Add : AgentControllerにAnimator設定用の各種パラメータ追加。
- Add : Waypointコンポーネント追加。
- Add : ParameterContainerで使用できるパラメータにComponent追加。
- Change : AgentControllerのAnimator指定をパラメータごとではなく統一するように変更。

* Script
- Add : Animatorの型ごとのパラメータ参照用クラス追加。
- Add : StateBehaviourの順でUpdate時に呼ばれるOnStateUpdateコールバック追加。
- Add : StateBehaviourの順でLateUpdate時に呼ばれるOnStateLateUpdateコールバック追加。
- Add : InputSlotUnityObject、OutputSlotUnityObject追加。
- Add : FlexibleComponent追加。
- Add : CalculatorSlotやFlexibleCompomentで型を指定できるSlotTyeAttribute追加。
- Add : ComponentParameterReference追加。
- Add : StateBehaviourとCalculatorの共通部分をまとめたNodeBehaviourクラス作成。
- Add : NodeBehaviourのシリアライズ時の処理を記述するためのinterface、INodeBehaviourSerializationCallbackReceiverを追加。
- Add : 各種Flexibleクラスにtypeとparameterプロパティ追加。
- Change : 各種ノードのIDをNode.nodeIDに統一。
- Change : ParameterクラスにToStringメソッド追加。
- Change : CalculatorBranchにupdatedTime追加。
- Change : InputSlotにisUsedとupdatedTime追加。
- Change : Transitionメソッドでの遷移タイミングの指定をTransitionTimingに変更。
- Change : CalculatorSlot.positionをNonSerializedに変更。
- Change : テンプレートにusing System.Collections.Generic;とAddComponentMenu("")を追加。
- Fix : EachFieldで基本クラスのフィールドを参照していなかったので修正。

Ver 2.1.8:

* Arbor Editor
- Fix : StateLinkやCalculatorSlotをドラッグ中にスクロールしてノードが表示されなくなるとドラッグ処理が行われなくなるのを修正。

Ver 2.1.7:

* Script
- Change : 無効なArborFSMのTransitionメソッドを呼び出した場合、immediateTransitionをtrueにしていても有効になるまで遷移を遅延させるように変更。

Ver 2.1.6:

* Arbor Editor
- Fix : ArborFSMのPrefabインスタンスにStateBehaviourを追加するとプレイ開始とともに例外が発生するのを修正。

Ver 2.1.5:

* Arbor Editor
- Fix : Arbor Editorウィンドウの高速化。

* 組み込み挙動
- Fix : RandomTransitionをInspectorのAdd Componentメニューに表示しないように修正。

Ver 2.1.4:

* Arbor Editor
- Fix : ノードをコピーするとプレイ開始時などに警告が表示されるのを修正。
- Fix : Prefab化しているインスタンスからのみノードを削除しているとプレイ開始時にノードが復活してしまう不具合を修正。

* Script
- Add : ArborFSMInternalに各種ノードのインデックスを取得するメソッドを追加 : GetStateIndex() , GetCommentIndex() , GetCalculatorIndex()

Ver 2.1.3:

* Arbor Editor
- Fix : ArborFSMをアタッチしているPrefabインスタンスのApplyボタンを押すと出る例外を修正。

Ver 2.1.2:

* Arbor Editor
- Add : ArborEditorウィンドウ上で実行中に任意のステートに遷移できる機能を追加。
- Fix : StateBehaviourとCalculatorのEditorで例外が発生した場合にArborEditorウィンドウが正常に表示されなくなるのを修正。
- Fix : StateBehaviourとCalculatorのスクリプトが読み込めない場合に出ていた例外を修正。
- Fix : ArborEditorを表示していると"NullReferenceException: SerializedObject of SerializedProperty has been Disposed."という例外がでることがあるのを修正。
- Fix : ArborEditorウィンドウの幅が狭くなった際にステートリストの幅が狭くなりすぎるのを修正。

* 組み込み挙動
- Change : Tween開始時の初期化用コールバックOnTweenBeginメソッド追加。
- Change : SendEventGameObjectのEventパラメータをOnStateBeginにリネーム。
- Add : SendEventGameObjectにOnStateAwakeイベントとOnStateEndイベント追加。

* Script
- Add : ParameterContainerで扱うすべての型のGet/Setメソッド追加。
- Add : ParameterContainerにGetParamIDメソッド追加。
- Add : ParameterContainerのGet/SetメソッドをIDからも行えるメソッド追加。
- Fix : 遷移処理中にSendTriggerを使用した場合、遷移処理が完了した後にTriggerを送るように修正。

Ver 2.1.1:

* Arbor Editor
- Change : ブレークポイントとステートカウントの表示を枠外に移動
- Fix : ParameterContainerのStringでコピー&ペーストできなかったのを修正。
- Fix : データスロットがスクリプトから削除された場合にCalculatorBranchも削除するように修正

Ver 2.1.0:

* Arbor Editor
- Add : GameObjectを選択しても切り替わらないようにロックするトグル追加。
- Add : StateBehaviourのタイトルバーをドラッグして並び替えできるように対応。
- Add : StateBehaviourをドラッグ&ドロップで任意の位置に挿入できるように対応。
- Add : Stateにブレークポイントを設定できるように対応。
- Add : 実行中にStateとStateLinkが通った回数を表示するように対応。
- Add : 実行中に直前に通ったStateLinkを強調表示するように対応。
- Add : 実行中にCalculaterBranchの値を表示するように対応。
- Add : 組み込みコンポーネントのヘルプボタンからヘルプページを開く。
- Add : 組み込みCalculatorのヘルプボタンからヘルプページを開く。
- Add : CalculatorBranchの型によって線の色を変更。
- Fix : ArborFSMを別のGameObjectに移動したときに入出力スロットからデータにアクセスできなくなっていたのを修正。
- Fix : Arbor Editorのグラフ表示エリアがずれるのを修正。
- Fix : ステートリストから選択する場合など、選択したステートまで自動的にスクロールした時にArbor Editorのグラフ表示が滲むのを修正。
- Add : ArborEditorウィンドウにアイコン追加

* 組み込み挙動
- Change : FindGameObject、FindWithTagGameObjectで見つけたGameObjectを演算ノードへ出力するように対応。
- Add : RandomTransition追加。
- Change : TimeTransitionにTimeTypeの指定を追加。
- Fix : Flexibleなコンポーネントの参照でのキャッシュ処理を修正。
- Fix : 配列にStateLinkがあるBehaviourでエディタ上で配列のサイズを減らすとエラーが出るのを修正。

* Script
- Change : OnStateTriggerをStateBehaviourの仮想関数に変更。
- Fix : AgentController.FollowとEscapeにnullが渡されたときにエラーが出ないように修正。

* その他
- Change : リファレンスサイトを更新。
- Change : Unity最低動作バージョンを5.3.0f4に引き上げ。

Ver 2.0.10:

* Arbor Editor
- Change : GameObjectを選択した際、Arbor Editorも連動して表示が切り替わるように対応。
- Fix : コメントを新規作成するとエラーが出るのを修正。
- Fix : ノードのコピーを行うとプレイ開始時にエラーが出るのを修正。
- Fix : ノードをコピーし一度プレイ開始したあとペーストできなくなるのを修正。
- Fix : Calculatorノードのコピーを修正。
- Fix : CalculatorSlotを持ったStateBehaviourやCalculatorをコピー&ペーストや複製した時の処理を修正。

Ver 2.0.9:

* Arbor Editor
- Fix : Unity5.6でArborEditorを開くとエラーが出るのを修正。
- Fix : Arbor Editorウィンドウの高速化。

* 組み込み挙動
- Change : CalculatorTransitionのBoolを２つのBool値を比較するように変更。

* スクリプト
- Change : State.behaviourCountとGetBehaviourFromIndex追加。State.behavioursを非推奨に。
- Change : ArborFSMInternal.stateCountとGetStateFromIndex追加。ArborFSMInternal.statesを非推奨に。
- Change : ArborFSMInternal.commentCountとGetCommentFromIndex追加。ArborFSMInternal.commentsを非推奨に。
- Change : ArborFSMInternal.calculatorCountとGetCalculatorFromIndex追加。ArborFSMInternal.calculatorsを非推奨に。
- Change : ArborFSMInternal.calculatorBranchCountとGetCalculatorBranchFromIndex追加。ArborFSMInternal.calculatorBranchiesを非推奨に。

Ver 2.0.8:

* Arbor Editor
- Fix : Unity5.3.4以降のArbor EditorでNodeやStateBehaviourをコピーするとエラーが表示されるのを修正。
- Change : ArborFSMが先に実行されるようにScript Execution Orderを変更。

Ver 2.0.7:

* Arbor Editor
- Add : OutputSlotStringとInputSlotString追加
- Add : FlexibleString追加
- Add : ParameterContainerにstring追加
- Add : CalcParameterにstringの処理追加
- Add : ParameterTransitionにstringによる遷移追加
- Add : UISetTextFromParameterにstringパラメータからのテキスト設定に対応
- Fix : OutputSlot/InputSlotをカスタマイズしたクラスを作成した際にArbor Editorにスロットが正常に表示されないのを修正

Ver 2.0.6:

* Arbor Editor
- Fix : ノードを削除したときのUndo/Redoを修正。
- Fix : StateBehaviourを削除した時のUndo/Redoを修正。

Ver 2.0.5:

* Arbor Editor
- Fix : 演算ノードやステート挙動を追加した時に、ArborEditorウィンドウを再描画するように修正。
- Fix : RectUtilityをArborEditor名前空間に修正。
- Fix : Boo用テンプレート修正。

* 組み込み挙動
- Change : Tween系のパラメータを演算ノードから受け取れるように変更。

Ver 2.0.4:

* Arbor Editor
- Add : Stateに初めて入った際にOnStateAwake()を呼ぶように追加。
- Fix : 遷移矢印を右クリックすると遷移先に移動できるメニューをMacでのcontrol+クリックでも表示するように修正。
- Fix : Unity5.5.0Betaでの警告とエラー修正。

Ver 2.0.3:
* Arbor Editor
- Fix : Unity5.4.0Betaで警告が出るのを修正
- Fix : ステートのペーストや複製時にマウスの位置にステートが生成されないのを修正

Ver 2.0.2:
* Arbor Editor
- Fix : Unity5.3.0以降のUnityエディタ上でArborFSMオブジェクトを選択したままプレイ開始するとStateBehaviourが削除されてしまうのを修正。

* 組み込み挙動
- Add : Scene/LoadLevelにAdditiveプロパティを設定できるように対応。
- Add : Scene/UnloadLevel追加(Unity5.2以降対応)。
- Fix : Unity5.3.0以降のScene/LoadLevelにてApplication.LoadLevelの警告が出るのを修正。

Ver 2.0.1:
* Arbor Editor
- Change : ヒープメモリの使用量を削減。
- Fix : コンパイルするたびにエディタ管理用オブジェクトが増えていたのを修正。

* 組み込み挙動
- Change : Audio/PlaySoundAtPointをAudio/PlaySoundAtTransformに改名。
- Add : Audio/PlaySoundAtTransformにAudioMixerGroupとSpatialBlendの指定を追加。
- Add : 新たに座標指定のAudio/PlaySoundAtPointを追加。

Ver 2.0.0:
* Arbor Editor
- Add : 演算ノード追加。
- Add : ParameterContainerでVector2を保持できるように対応。
- Add : ParameterContainerでVector3を保持できるように対応。
- Add : ParameterContainerでQuaternionを保持できるように対応。
- Add : ParameterContainerでRectを保持できるように対応。
- Add : ParameterContainerでBoundsを保持できるように対応。
- Add : ParameterContainerでTransformを保持できるように対応。
- Add : ParameterContainerでRectTransformを保持できるように対応。
- Add : ParameterContainerでRigidbodyを保持できるように対応。
- Add : ParameterContainerでRigidbody2Dを保持できるように対応。

* 組み込み挙動
- Add : Transition/Physics/RaycastTransition
- Add : Transition/Physics2D/Raycast2DTransition
- Add : Transition/CalculatorTransition
- Add : InstantiateGameObjectに生成したGameObjectの出力を追加
- Add : OnCollisionEnterTransitionに当たった相手のCollisionの出力を追加
- Add : OnCollisionExitTransitionに当たった相手のCollisionの出力を追加
- Add : OnCollisionStayTransitionに当たった相手のCollisionの出力を追加
- Add : OnTriggerEnterTransitionに当たった相手のColliderの出力を追加
- Add : OnTriggerExitTransitionに当たった相手のColliderの出力を追加
- Add : OnTriggerStayTransitionに当たった相手のColliderの出力を追加
- Add : OnCollisionEnter2DTransitionに当たった相手のCollision2Dの出力を追加
- Add : OnCollisionExit2DTransitionに当たった相手のCollision2Dの出力を追加
- Add : OnCollisionStayT2Dransitionに当たった相手のCollision2Dの出力を追加
- Add : OnTriggerEnter2DTransitionに当たった相手のCollider2Dの出力を追加
- Add : OnTriggerExit2DTransitionに当たった相手のCollider2Dの出力を追加
- Add : OnTriggerStayT2Dransitionに当たった相手のCollider2Dの出力を追加
- Change : AgentEscapeをFlexibleTransformに対応。
- Change : AgentFllowをFlexibleTransformに対応。
- Change : PlaySoundAtPointをFlexibleTransformに対応。
- Change : InstantiateGameObjectをFlexibleTransformに対応。
- Change : LookAtGameObjectをFlexibleTransformに対応。
- Change : AddForceRigidbodyをFlexibleRigidbodyに対応。
- Change : AddVelocityRigidbodyをFlexibleRigidbodyに対応。
- Change : SetVelocityRigidbodyをFlexibleRigidbodyに対応。
- Change : AddForceRigidbody2DをFlexibleRigidbody2Dに対応。
- Change : AddVelocityRigidbody2DをFlexibleRigidbody2Dに対応。
- Change : SetVelocityRigidbody2DをFlexibleRigidbody2Dに対応。

* 組み込み演算
- Add : BoolのCalculator追加
- Add : BoundsのCalculator追加
- Add : ColliderのCalculator追加
- Add : Collider2DのCalculator追加
- Add : CollisionのCalculator追加
- Add : Collision2DのCalculator追加
- Add : ComponentのCalculator追加
- Add : FloatのCalculator追加
- Add : IntのCalculator追加
- Add : MathfのCalculator追加
- Add : QuaternionのCalculator追加
- Add : RaycastHitのCalculator追加
- Add : RaycastHit2DのCalculator追加
- Add : RectのCalculator追加
- Add : RectTransformのCalculator追加
- Add : RigidbodyのCalculator追加
- Add : Rigidbody2DのCalculator追加
- Add : TransformのCalculator追加
- Add : Vector2のCalculator追加
- Add : Vector3のCalculator追加

* スクリプト
- Add : FlexibleBounds実装
- Add : FlexibleQuaternion実装
- Add : FlexibleRect実装
- Add : FlexibleRectTransform実装
- Add : FlexibleRigidbody実装
- Add : FlexibleRigidbody2D実装
- Add : FlexibleTransform実装
- Add : FlexibleVector2実装
- Add : FlexibleVector3実装

Ver 1.7.7p2:
* Arbor Editor
- Fix : Unity5.2.1以降でエラーが出るのを修正。

Ver 1.7.7p1:
* Arbor Editor
- Fix : ステートとコメントの作成と削除がUndoできなかったのを修正。

Ver 1.7.7:
* Arbor Editor
- Add : ParameterContainerでGameObjectを保持できるように対応。
- Change : 自分自身のステートへ遷移できるように変更。
- Change : 挙動の背景を変更。
- Change : ListGUIの背景を変更。
- Change : コメントノードを内容によってリサイズするように変更。
- Fix : Undo周りのバグ修正
- Fix : 常駐ステートが開始ステートに設定できたのを修正。
- Other : グリッドなどの設定をプロジェクトごとではなくUnityのメジャーバージョンごとに保存するように対応。

* 組み込み挙動
- Add : Collision/OnCollisionEnterStore
- Add : Collision/OnCollisionExitStore
- Add : Collision/OnControllerColliderHitStore
- Add : Collision/OnTriggerEnterStore
- Add : Collision/OnTriggerExitStore
- Add : Collision2D/OnCollisionEnter2DStore
- Add : Collision2D/OnCollisionExit2DStore
- Add : Collision2D/OnTriggerEnter2DStore
- Add : Collision2D/OnTriggerExit2DStore
- Add : GameObject/FindGameObject
- Add : GameObject/FindWithTagGameObject
- Add : UITweenPositionに相対指定できるように追加。
- Add : UITweenSizeに相対指定できるように追加。
- Change : BroadcastMessageGameObjectの値をFlexibleIntなどを使用するように対応。
- Change : CalcAnimatorParameterの値をFlexibleIntなどを使用するように対応。
- Change : CalcParameterの値をFlexibleIntなどを使用するように対応。
- Change : ParameterTransitionの値をFlexibleIntなどを使用するように対応。
- Change : SendMessageGameObjectの値をFlexibleIntなどを使用するように対応。
- Change : SendMessageUpwardsGameObjectの値をFlexibleIntなどを使用するように対応。
- Change : AgentEscapeをArborGameObjectに対応。
- Change : AgentFllowをArborGameObjectに対応。
- Change : ActivateGameObjectをFlexibleGameObjectに対応。
- Change : BroadastMessageGameObjectをFlexibleGameObjectに対応。
- Change : DestroyGameObjectをFlexibleGameObjectに対応。
- Change : LookatGameObjectをFlexibleGameObjectに対応。
- Change : SendMessageGameObjectをFlexibleGameObjectに対応。
- Change : SendMessageUpwardsGameObjectをFlexibleGameObjectに対応。
- Change : BroadcastTriggerをFlexibleGameObjectに対応。
- Change : SendTriggerGameObjectをFlexibleGameObjectに対応。
- Change : SendTriggerUpwardsをFlexibleGameObjectに対応。
- Change : InstantiateGameObjectで生成したオブジェクトをパラメータに格納できるように対応。

* スクリプト
- Add : FlexibleInt実装
- Add : FlexibleFloat実装
- Add : FlexibleBool実装
- Add : FlexibleGameObject実装
- Add : ContextMenuを使えるように対応。

* その他
- Change : Parameter関連をCoreフォルダとInternalフォルダに移動。
- Other : コンポーネントにアイコン設定。

Ver 1.7.6:
* Arbor Editor
- Add : StateLinkに名前設定追加。
- Add : StateLinkに即時遷移フラグ追加。
- Fix : 挙動追加での検索文字列が保存できていなかったのを修正。
- Other : 挙動追加を開いた際、検索バーにフォーカスが移るように対応。
- Other : 挙動追加での並び順で、グループが先に来るように調整。

* コンポーネント
- Add : GlobalParameterContainer

* 組み込み挙動
- Add : Audio/PlaySound
- Add : Audio/StopSound
- Add : Collision/OnCollisionEnterDestroy
- Add : Collision/OnCollisionExitDestroy
- Add : Collision/OnControllerColliderHitDestroy
- Add : Collision2D/OnCollisionEnter2DDestroy
- Add : Collision2D/OnCollisionExit2DDestroy
- Add : GameObject/BroadcastMessageGameObject
- Add : GameObject/SendMessageUpwardsGameObject
- Add : Physics/AddForceRigidbody
- Add : Physics/AddVelocityRigidbody
- Add : Physics2D/AddForceRigidbody2D
- Add : Physics2D/AddVelocityRigidbody2D
- Add : Renderer/SetSprite
- Add : Transition/Collision/OnCollisionEnterTransition
- Add : Transition/Collision/OnCollisionExitTransition
- Add : Transition/Collision/OnCollisionStayTransition
- Add : Transition/Collision/OnControllerColliderHitTransition
- Add : Transition/Collision2D/OnCollisionEnter2DTransition
- Add : Transition/Collision2D/OnCollisionExit2DTransition
- Add : Transition/Collision2D/OnCollisionStay2DTransition
- Add : Transition/Input/ButtonTransition
- Add : Transition/Input/KeyTransition
- Add : Transition/Input/MouseButtonTransition
- Add : Transition/ExistsGameObjectTransition
- Add : Trigger/BroadcastTrigger
- Add : Trigger/SendTriggerGameObject
- Add : Trigger/SendTriggerUpwards
- Add : Tween/TweenRigidbody2DPosition
- Add : Tween/TweenRigidbody2DRotation
- Add : Tween/TweenTextureOffset
- Add : UI/UISetSlider
- Add : UI/UISetSliderFromParameter
- Add : UI/UISetToggle
- Add : UI/UISetToggleFromParameter
- Add : TimeTransitionに現在時間をプログレスバーで表示するように追加。
- Add : Tween終了時に遷移できるように追加。
- Add : TweenPositionに相対指定できるように追加。
- Add : TweenRotationに相対指定できるように追加。
- Add : TweenScaleに相対指定できるように追加。
- Add : TweenRigidbodyPositionに相対指定できるように追加。
- Add : TweenRigidbodyRotationに相対指定できるように追加。
- Fix : OnTriggerExit2DDestroyがCollisionにあったのを修正。
- Fix : CalcAnimatorParameterのfloatValueがintになっていたのを修正。
- Fix : CalcParameterのfloatValueがintになっていたのを修正。
- Fix : ParameterTransitionのfloatValueがintになっていたのを修正。
- Other : SetRigidbodyVelocityをSetVelocityRigidbodyに改名。
- Other : SetRigidbody2DVelocityをSetVelocityRigidbody2Dに改名。

* スクリプト
- Add : FixedImmediateTransition属性で即時遷移フラグを変更できないように対応。

* その他
- Add : Example9としてGlobalParameterContainerのサンプル追加。
- Fix : TagsにCoinが追加されていたので修正。

Ver 1.7.5:
* Arbor Editor
- Fix : グリッドが正しく表示されない時があるのを修正。
- Other : ステートリストの横幅をリサイズできるように対応。

* 組み込み挙動
- Add : Collision/OnTriggerEnterDestroy
- Add : Collision/OnTriggerExitDestroy
- Add : Collision2D/OnTriggerEnter2DDestroy
- Add : Collision2D/OnTriggerExit2DDestroy
- Add : GameObject/LookAtGameObject
- Add : Parameter/SetBoolParameterFromUIToggle
- Add : Parameter/SetFloatParameterFromUISlider
- Add : Physics/SetRigidbodyVelocity
- Add : Physics2D/SetRigidbody2DVelocity
- Add : Transition/EventSystems/OnPointerClickTransition
- Add : Transition/EventSystems/OnPointerDownTransition
- Add : Transition/EventSystems/OnPointerEnterTransition
- Add : Transition/EventSystems/OnPointerExitTransition
- Add : Transition/EventSystems/OnPointerUpTransition
- Add : Tween/TweenCanvasGroupAlpha
- Add : Tween/TweenRigidbodyPosition
- Add : Tween/TweenRigidbodyRotation
- Add : UI/UISetImage
- Add : UI/UISetTextFromParameter
- Add : InstantiateGameObjectで生成時の初期Transformを指定できるように追加。
- Fix : CalcParameterでBool型の場合に正しく動作しなかったのを修正。
- Fix : SendEventGameObjectで呼び出す方をわざわざ指定しないように修正。

* スクリプト
- Add : Parameterにvalueプロパティ追加。
- Add : IntParameterReference追加。
- Add : FloatParameterReference追加。
- Add : BoolParameterReference追加。

* その他
- Add : HierarchyのCreateボタンからArborFSM付きGameObjectを作れるように追加。
- Add : HierarchyのCreateボタンからParameterContainer付きGameObjectを作れるように追加。
- Add : HierarchyのCreateボタンからAgentController付きGameObjectを作れるように追加。
- Add : Example7としてコインプッシャーゲーム追加。
- Add : Example8としてEventSystemのサンプル追加。
- Other : フォルダ整理。

Ver 1.7.4:
- Add : Agent系Behaviour追加。
- Add : uGUI系Behaviour追加。
- Add : uGUI系Tween追加。
- Add : SendEventGameObject追加。
- Add : SendMessageGameObjectに値渡し機能追加。
- Fix : AnimatorParameterReferenceの参照先がAnimatorControllerを参照していなかったときにエラーが出るのを修正。
- Other : uGUI対応に伴いUnity最低動作バージョンを4.6.7f1に引き上げ。

Ver 1.7.3:
- Add : OnMouse系Transition追加
- Fix : 選択ステートへの移動時のスクロール位置修正
- Other : ステートリストを名前順でソートするように変更。
- Other : Arbor Editorの左上方向へも無限にステートを配置できるように変更。
- Other : マニュアルサイトを一新。

Ver 1.7.2:
- Add : ArborEditorにコメントノードを追加。
- Add : 挙動追加時に検索できるように対応。
- Add : CalcAnimatorParameter追加。
- Add : AnimatorStateTransition追加。
- Add : 遷移線を右クリックで遷移元と遷移先へ移動できるように追加。
- Fix : Prefab元に挙動追加するとPrefab先に正しく追加されないのを修正。
- Other : ForceTransitionをGoToTransitionに改名。
- Other : 挙動追加で表示される組み込みBehaviourの名前を省略しないように変更。
- Other : 組み込みBehaviourをAdd Componentに表示しないように変更。

Ver 1.7.1:
- Add : ステートリストを追加。
- Add : ParamneterReferenceのPropertyDrawerを追加。
- Add : 要素の削除ができるリスト用のGUI、ListGUIを追加。
- Fix : CalcParameterのboolValueがintになっていたのを修正。

Ver 1.7.0;
- Add : パラメータコンテナ。
- Fix : OnStateBegin()で状態遷移した場合、それより下のBehaviourを実行しないように修正。

Ver 1.6.3f1:
- Unity5 RC3でエラーが出るのを修正。
- Unity5 RC3対応により、OnStateEnter/OnStateExitをOnStateBegin/OnStateEndに改名。

Ver 1.6.3:
- Transitionにforceフラグを追加。trueにすると呼び出し時にその場で遷移するようにできる。
- ソースコードへドキュメントコメント埋め込み。
  Player Settings の Scripting Define Symbols に ARBOR_DOC_JA を追加すると日本語でドキュメントコメントが見れるようになります。
- スクリプトリファレンスをAssets/Arbor/Docsに配置。
  解凍してindex.htmlを開いてください。

Ver 1.6.2:
- FIX : OnStateEnterでステート遷移できないのを修正。

Ver 1.6.1:
- FIX : Mac環境でGridボタン押すとエラーが表示される。

Ver 1.6:
- ADD : 常駐ステート。
- ADD : 多言語対応。
- ADD : ArborFSMに名前を付けられるように対応。
- FIX : グリッドサイズを変更してもスナップ間隔に反映されない。
- FIX : ArborFSMのコンポーネントをコピー＆ペーストした際にStateBehaviourが消失する問題の対処。
- FIX : SendTriggerを現在有効なステートにのみ送るように変更。
- FIX : ArborFSMを無効にしてもStateBehaviourが動き続ける。

Ver 1.5:
- ADD : ステートの複数選択に対応。
- ADD : ショートカットキーに対応。
- ADD : グリッド表示対応。
- FIX : Behaviour追加時にデフォルトで広げた状態にする。
- FIX : StateLinkのドラッグ中にステートへのマウスオーバーがずれて反応する。
 
ver 1.4:
- ADD : Tween系Behaviour追加。
 - Tween / Color
 - Tween / Position
 - Tween / Rotation
 - Tween / Scale
- ADD : Add Behaviourに表示されないようにするHideBehaviour属性追加。
- ADD : Behaviourのヘルプボタンから組み込みBehaviourのオンラインヘルプ表示。

ver 1.3:
- ADD : 組み込みBehaviour追加。
 - Audio / PlaySoundAtPoint
 - GameObject / SendMessage
 - Scene / LoadLevel
 - Transition / Force
- ADD : シーンを跨いだコピー&ペースト。
- FIX : Stateをコピーしたあとシーンを保存するとメモリリークの警告が表示される。
- FIX : StateLinkの接続ドラッグ中に画面スクロールすると矢印が残る。

ver 1.2:
- ADD : StateBehaviourの有効チェックボックス。
- FIX : Arbor Editorの最大化を解除するとエラーが出る。
- FIX : 生成したC#スクリプトを編集すると改行コードの警告が出る。

ver 1.1:
- ADD : JavaScriptとBooのスクリプト生成。
- ADD : Stateのコピー＆ペースト。
- ADD : StateBehaviourのコピー＆ペースト。
- FIX : スクリプトがMissingになったときの対応。
- FIX : StateLinkの配列が表示されないのを修正。

ver 1.0.1:
- FIX : Unity4.5でのエラー。
- FIX : エディタ上での実行時にArbor Editorが再描画されない。
- FIX : ArborFSMのInspector拡張のクラス名。
