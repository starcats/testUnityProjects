-----------------------------------------------------
            Arbor 3: FSM & BT Graph Editor
          Copyright (c) 2014 Cait Sith Ware
          https://caitsithware.com/wordpress/
          support@caitsithware.com
-----------------------------------------------------

Thank you for downloading Arbor3 Trial version!

# Restriction on Trial version

1. DLL

* Core processing can not be edited because it is made into DLL.
* Reverse engineering is prohibited.

2. Runtime restrictions

* Invalidate state transition after 2 minutes from game start.
* Display of "Arbor3 Trial" on game screen.
* (Play on the Unity editor is available without restriction)

3. Build restrictions

* IL2CPP build not available.
* UWP build not available.

4. Arbor Editor Window

* Open Asset Store button display.
* Zoom not available.
* Graph capture not available.

# Main flow

1. Creating a GameObject with ArborFSM

	There are the following methods for creating.
	* Select Arbor / ArborFSM from Hierarchy's Create button to create GameObject.
	* If there is already a created GameObject, select Arbor / ArborFSM from the Inspector's Add Component button.

2. Open the Arbor Editor window

	* Click the Open Editor button in ArborFSM Inspector.

3. State creation

	* Right-click inside the graph in Arbor Editor and select "Create State".

4. Add state behavior

	* Right click on the header part of the created state or click the gear icon and select "Add Behavior".
	  Select the behavior you want to add in the AddBehaviourMenu window that is displayed.

	  Please refer to the reference page below for the behaviors added by the built-in.
	  https://arbor-docs.caitsithware.com/en/

5. Connect transitions from behaviors

	For behavior with a StateLink class field for transition connections, you can connect to other states.
	* Drag the StateLink field and connect it by dropping it on other states.

# Example scene

The example scene is in the following folder in the project.
Assets/Plugins/Arbor/Examples/

# Document

Click here for detailed document. 
https://arbor.caitsithware.com/en/

# Asset Store

Purchase here!
https://www.assetstore.unity3d.com/#!/content/112239

# Support

Forum : https://forum-arbor.caitsithware.com/?language=en

Mail : support@caitsithware.com

# Release Note

Ver 3.4.2:

[FIXES]

* Arbor Editor

- Fixed a bug that NullReferenceException occurred in StateBehaviour with ArborFSM array and List.

Ver 3.4.1:

[FIXES]

* ParameterContainer

- Fixed a bug that when Object related parameters were added before Arbor 3.3.2, errors occurred when loading.

* Scripts

- Fixed that NullReferenceException occurs when ParameterCondition reads scenes at run time while keeping old format.
  [Related behavior]
    - [StateBehaviour] ParameterTransition
	- [Decorator] ParameterCheck
	- [Decorator] ParameterConditionalLoop
- Fixed that NullReferenceException occurs when CalculatorCondition reads scenes at runtime while keeping old format.
  [Related behavior]
    - [StateBehaviour] CalculatorTransition
	- [Decorator] CalculatorCheck
	- [Decorator] CalculatorConditionalLoop

Ver 3.4.0:

[What's New]

* Parameters in node graph

A parameter function directly related to ArborFSM and Behavior tree was added.
You can create it from the "Parameters" tab of the side panel.

Parameters can be accessed from the graph by dragging and dropping from the dragging area of the parameter to the graph view.

* Data transfer to subgraph

Added access field to graph parameter in Subgraph related behavior such as SubStateMachine and SubBehaviourTree.

* Resize node

We added a function that can change by dragging the width of various nodes (Except for some nodes such as the root node of Behavior tree)

* Align within group nodes

Added a function to automatically adjust nodes so that they do not overlap when the position and size of nodes in group nodes are changed.

You can set "Auto Alignment" from the group node setting window.

[ADDITION]

* Arbor Editor

- Added parameter tab to side panel.
- Added size change of various nodes.
- Added alignment function within group nodes.

* ParameterContainer

Added drag area for creating parameter access node.

* Built-in StateBehaviour

- Added method setting to make transition call to GoToTransition.
- Added PlayStateMachine to start playback of ArborFSM.
- Added StopStateMachine to stop playback of ArborFSM.
- Added PlayBehaviourTree to start playback BehaviourTree.
- Added StopBehaviourTree to stop playback BehaviourTree.
- SendMessageGameObject, SendMessageUpwardsGameObject, BroadcastMessageGameObject
    - Change MethodName field to FlexibleString type.
    - Added available types for arguments
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

* Built-in ActionBehaviour

- Added PlayStateMachine to start playback of ArborFSM.
- Added StopStateMachine to stop playback of ArborFSM.
- Added PlayBehaviourTree to start playback BehaviourTree.
- Added StopBehaviourTree to stop playback BehaviourTree.

* Scripts

- Added access method to Enum type parameter to ParameterContainer.

[IMPROVEMENT]

* Arbor Editor

- Adjust the starting position of the StateLink connection line.
- Improved editor performance.
- Improved to cache the search word of the script selection window such as StateBehaviour for each type of script.
- Improved to display data connection lines where data is not stored during execution as dark.

* ParameterContainer

- Improved to serialize each parameter only the necessary minimum data.

* Scripts

- Improved to serialize each element of ParameterCondition only necessary minimum data.
  [Related Behaviours]
    - [StateBehaviour] ParameterTransition
	- [Decorator] ParameterCheck
	- [Decorator] ParameterConditionalLoop
- Improved to serialize each element of CalculatorCondition only necessary minimum data.
  [Related Behaviours]
    - [StateBehaviour] CalculatorTransition
	- [Decorator] CalculatorCheck
	- [Decorator] CalculatorConditionalLoop

[FIXES]

* Arbor Editor

- Fixed the connection position of the connection line of the data with the Behaviour collapsed.
- Fixed creation positions of nodes when creating the node by dragging the connection slots of each node BehaviourTree.
- Fixed that the help box displayed when one of the ArborEditor windows can not be used is displayed one line when there is no data slot label.
- Fixed output of log when deleting each element of WeightList used in Random.SelectComponent etc.
- Fixed an issue where NullReferenceException may occur when playing with live tracking on.
- FixibleField reference type DataSlot is displayed as Calculator.
- Fixed a bug that disconnected when you re-select the reference type of FlexibleField to DataSlot.

* Scripts

- Fixed that NullReferenceException occurs when the input slot of data is connected only to the reroute node and it is not connected to the output slot.

* Unity support

- Support for Unity 2018.3.0f1
- Support for Unity2019.1.0a10

* "Odin - Inspector and Serializer" Support

- Temporarily deal with the problem that some PropertyDrawer were not working properly.

Annotation: 
  Cooperation with other assets is outside the guarantee of operation in principle.
  There is no guarantee that the problem is not generated by this deal.

Ver 3.3.2:

[CHANGES]

* Arbor Editor

- Changed to use the button style for the icon button of the node header.
- When StateLink is connected, change the background style so that the gear icon is easy to see.

[FIXES]

* Arbor Editor

- Support for Unity 2019.1.0a5.

* Build

- Fixed an error when building to Universal Windows Platform.

Ver 3.3.1:

[FIXES]

* Arbor Editor

- Fixed a bug that an error box is displayed in the field of the data slot when canceling Maximize of docked ArborEditor window.
- Fixed a bug that separator line between side panel and graph view is not displayed in Unity 2017.3.0 or later.

* ArborFSM

- Fixed a bug that transition count of StateLink which could not be reserved increases when transitioning with TransitionTiming.LateUpdateDontOverwrite.
- Fixed a bug that transition count does not increase when StateLink's TransitionTiming is Immediate.

Ver 3.3.0:

[New: InvokeMethod]

Added built-in script which calls method of Component.
You can input arguments from the data flow and output return values and out arguments to the data flow.

* Built-in StateBehaviour

- Added InvokeMethod.

* Scripts

- Added ArborEvent class (Core classes to perform the method call)
- Added ShowEventAttribute class (Attributes that can be selected even for methods with arguments of type not supported)
- Added HideEventAttribute class (Attribute to be hidden so that it can not be selected by ArborEvent)

[New: ObjectPool]

Added function to pool instantiated objects.

* Built-in StateBehaviour

- Added AdvancedPooling which performs advance pooling.
- Add UsePool flag to instantiate from ObjectPool.
    - InstantiateGameObject
	- SubStateMachineReference
	- SubBehaviourTreeReference
- Changed to return to ObjectPool at Destroy.
  (Return to Pool only when Instantiating from ObjectPool)
	- DestroyGameObject
	- OnCollisionEnterDestroy
	- OnCollisionExitDestroy
	- OnTriggerEnterDestroy
	- OnTriggerExitDestroy
	- OnCollisionEnter2DDestroy
	- OnCollisionExit2DDestroy
	- OnTriggerEnter2DDestroy
	- OnTriggerExit2DDestroy

* Built-in ActionBehaviour

- Added AdvancedPooling which performs advance pooling.
- Add UsePool flag to instantiate from ObjectPool.
    - InstantiateGameObject
	- SubStateMachineReference
	- SubBehaviourTreeReference
- Changed to return to ObjectPool at Destroy.
  (Return to Pool only when Instantiating from ObjectPool)
    - DestroyGameObject

* Scripts

- Added ObjectPool class to ObjectPooling namespace.

[ADDITION]

* Arbor Editor

- Added "Delete (Keep Connection)" in the right click menu of the data slot reroute node.
- Added "Delete (Keep Connection)" in the right click menu of the StateLink reroute node.
- Added "Disconnect" in the right-click menu of the data slot. ("Disconnect All" in case of output slot)
- Added "Edit Editor Script" in the menu of NodeBehaviour. (Only when there is an Editor extension script)
- Added "Show all data values always" check in the debug menu on the toolbar.

* ArborFSM

- Added infinite loop debug setting.

* BehaviourTree

- Added infinite loop debug setting.

* ParameterContainer

- Added enum type.

* Built-in StateBehaviour

- Added support for enum type of CalcParameter.
- Added support for enum type of ParameterTransition.
- Added "Save To Prefab" in SubStateMachine's menu.
- Added "Save To Prefab" in SubBehavioutTree's menu.

* Built-in ActionBehaviour

- Added "Save To Prefab" in SubStateMachine's menu.
- Added "Save To Prefab" in SubBehavioutTree's menu.

* Built-in Decorator

- Added support for enum type of ParameterCheck.
- Added support for enum type of ParameterConditionLoop.

* Editor extension

- Added LanguagePath asset which specifies installation directory path of self-created script language file.

* Scripts

- Added OutputSlotTypable class.
- Added InputSlotTypable class.
- Added FlexibleEnumAny class (FlexibleField system class that can handle enum)
- ArborFSMInternal class
    - Added prevTransitionState property which can refer to the state before transition.
    - Added nextTransitionState property which can refer to state after transition.
- StateBehaviour class
    - Added prevTransitionState property which can refer to the state before transition.
    - Added nextTransitionState property which can refer to state after transition.
    - Added stateLinkCount property to return the number of StateLink.
    - Added GetStateLink method to return StateLink.
    - Added RebuildStateLinkCache method to rebuild StateLink cache.
- Added Disconnect method to DataSlot class.
- Added AddBehaviourMenu multilingual support.
- Added BehaviourTitle multilingual support.
- Added BehaviourMenuItem multilingual support.

[CHANGES]

* Arbor Editor

- Changed to prevent nodes from being selected when clicking the node's main content GUI.
- Change GUI style of data slot.
- Changed to display the type name on tooltip when mouse over the reroute node of data slot.
- Integrate StateLink reroute node pin menu into node's right click menu.
- Changed to not change the connection destination when StateLink is dragged and it is in the stateLink frame.
- Changed GUI style of NodeLinkSlot of BehaviourTree.
- Changed to display the current condition of the decorator.
- Adjust the display position of the behaviour selection popup when pressing the insert behaviour button.
- Changed to display on the front when mouse over the connection line.
- Changed to be able to select None in the type selection popup.
- Supports selection of type selection popup window with key input.
- Changed ParameterContainer referenced by ParameterReference so that it can also be set from data slot.
- Adjust the color of connecting lines of other data types.

* BehaviourTree

- When Decorator returns failure on node active, change ActionBehaviour and Service OnStart () not to call.

* Built-in StateBehaviour

- Changed "Prefab" field of InstantiateGameObject to FlexibleComponent.
- Changed "External FSM" field of SubStateMachineReference to FlexibleComponent.
- Changed "External BT" field of SubBehaviourTreeReference to FlexibleComponent.

* Built-in ActionBehaviour

- Changed "Prefab" field of InstantiateGameObject to FlexibleComponent.
- Changed "External FSM" field of SubStateMachineReference to FlexibleComponent.
- Changed "External BT" field of SubBehaviourTreeReference to FlexibleComponent.

[OPTIMIZE]

* Arbor Editor

- Optimize by changing Reflection to delegate.

* ArborFSM

- Changed StateLink to cache beforehand.

* Scripts

- Changed EachField class to cache the field.
- Optimized by changing Reflection use of EachField class to delegate. (No change in AOT or IL2CPP environment)

[OBSOLETE]

* Scripts

- Change the nextState property of ArborFSMInternal to obsolete.
  (Added reserverdState instead)
- Changed the TidyAssemblyTypeName method of ClassTypeReference to obsolete.
　(Added TypeUtility.TidyAssemblyTypeName instead)
- Changed the GetAssemblyType method of ClassTypeReference to Obsolete.
  (Added TypeUtility.GetAssemblyType instead)

[FIXES]

* Arbor Editor

- Fix to switch Arbor Editor selection when Hierarchy selected graph instantiated by SubStateMachineReference or SubBehaviourTreeReference.
- Fixed an exception occurred in the editor when there was a class named StateLink different from Arbor.StateLink.
- Fixed that connection was broken when Undo insertion of reroute node of data slot.
- Fixed that rendering of dragging connection line was done even in other than Repaint event.

* ArborFSM

- A bug when calling Stop() on the same graph in OnStateBegin()
	- Fixed an exception occurred.
    - Fixed that OnStateEnd() and OnStateBegin() on next execution will not be called.
	- Fixed that OnStateBegin () after this state was called.
- Fix to hide fields not wanted to be edited from Inspector of ArborFSM instantiated by SubStateMachineReference.
- Fixed that extra copies of NodeBehaviours used in child graphs by SubStateMachine etc. when "Copy Component" was done in Inspector.

* BehaviourTree

- Fix to hide fields not wanted to be edited from Inspector of BehaviourTree instantiated by SubBehaviourTreeReference.
- Fixed that extra copies of NodeBehaviours used in child graphs by SubStateMachine etc. when "Copy Component" was done in Inspector.

* Waypoint

- Fixed deleting the next element when deleting an element for which Points' Transform is not set.

* Scripts

- Fixed bug that can not be found when passing target type array to EachField.Find.
- Fixed not to scan the contents when passing an instance of target type to EachField.Find.
- Fixed deleting the next element when WeightList<T> element type is Unity object and trying to delete an element not setting object.

* Others

- Support for Unity 2018.3.0b3.

Ver 3.2.4:

[FIXES]

* Arbor Editor

- Fixed a bug that caused an exception when trying to copy a character string of node comment in Unity 2017.3 or later.
- Fixed a bug that copying with the right-click menu of intra-node TextField does not work in Unity 2018.1 or later.
- Fixed a bug that automatic scrolling keeps working when dragging and dropping behaviors in MacOS Unity 2017.3 or later.
- Fixed a bug that a useless separator is displayed in the right click menu of the reroute node.
- Fixed that the display position of behavior insertion button on zoom out was slightly misaligned.
- Fix wording of behavior collapse.

Ver 3.2.3:

[FIXES]

* Arbor Editor

- Fixed using method which became Obsolete with Unity 2018.1.

* Built-in Behaviour

- Fixed that AngularSpeed property of AgentLookAtPosition was not displayed.
- Fixed that AngularSpeed property of AgentLookAtTransform was not displayed.

Ver 3.2.2:

[FIXES]

* Arbor Editor

- Fixed that it is not immediately reflected on the connection line when undoing the direction change of the reroute node of data.
- Fixed that if you undo the state move when the state is outside the screen, it will not be immediately reflected on the connection line.

* Other

- Fixed that Arbor group may not be displayed on Hierarchy's Create button when importing other asset etc

Ver 3.2.1:

[FIXES]

* Arbor Editor

- Fixed that inserting position becomes one before if behavior is added from insert button after dragging behavior once.

* ArborFSM

- Fixed that the state of the transition destination state is processed with LateUpdate() of the same frame after transition by TransitionTiming.Immediate in OnStateUpdate().

* BehaviourTree

- Fixed that common menu items of composite node and action node were missing.

Ver 3.2.0:

[ADDITION]

* Arbor Editor

- Added "Edit Script" to the right-click menu of the Calculator.
- Added color change of group node.
- Added "Settings" in the right-click menu of the transition line.
- Added drag-and-drop behavior to the Inspector.
- Added drag-and-drop behavior to another node.
	- Copy with Ctrl + Drop (Option + Drop on Mac).
- Added insert behavior button.
- Added expansion and collapse of behavior within the node.
	- Node right click menu
	- Graph right click menu (Selection nodes)
	- Toolbar (All nodes)
- Added active node tracking during play.
	- Switch with the "Live Tracking" toggle on the toolbar.
- Added setting items of ArborEditor
	- Docking Open : Set whether to dock with SceneView when the ArborEditor window is opened
	- Mouse Wheel Mode : Set whether to zoom or scroll (Unity 2017.3 or later)
	- Live Tracking Hierarchy : When "Live Tracking" is done, it is set whether to switch automatically to a child graph
- Added display of the area to be automatically scrolled when mouse over occurs during dragging.

* Behaviour Tree

- Added "Replace Composite" to the right-click menu of the composite node.
- Added "Replace Action" to the right-click menu of the action node.

* Parameter Container

- Added constructor and type conversion of FlexibleField to Variable script template.

* Built-in Behaviour

- Added a movement mode from the current value to the value specified for Tween behavior.
  (Along with this, change Relative field to TweenMoveType field)
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
- Added TweenColorSimple.
- Added UITweenColorSimple.
- Added TweenTextureScale.
- Added TweenMaterialFloat.
- Added TweenMaterialVector2.
- Added TweenTimeScale.
- Added TweenBlendShapeWeight.

* Built-in Calculator

- Added Random.Value.
- Added Random.InsideUnitCircle.
- Added Random.InsideUnitSphere.
- Added Random.OnUnitSphere.
- Added Random.Rotation.
- Added Random.RotationUniform.
- Added Random.RangeInt.
- Added Random.RangeFloat.
- Added Random.Bool.
- Added Random.RangeVector2.
- Added Random.RangeVector3.
- Added Random.RangeQuaternion.
- Added Random.RangeColor.
- Added Random.RangeColorSimple.
- Added Random.SelectString.
- Added Random.SelectGameObject.
- Added Random.SelectComponent.

* Built-in CompositeBehaviour

- Added RandomExecutor.
- Added RandomSelector.
- Added RandomSequencer.

* Built-in Variable

- Added Gradient.
- Added AnimationCurve.

* Scripts

- Added classes that can use ClassTypeConstraint attribute.
	- AnyParameterReference
	- ComponentParameterReference
	- InputSlotComponent
	- InputSlotUnityObject
	- InputSlotAny
	- FlexibleComponent
- Added ClassGenericArgumentAttribute.
- Added TryGetInt method etc. to ParameterContainer.
- Added a GetInt method etc. that can specify the default value when there is no parameter to ParameterContainer.
- Added EulerAnglesAtribute to enable Quaternion to be edited at Euler angles.
	- Added to Quaternion of Parameter.
	- Added to FlexibleQuaternion.
- Added AddVariableMenu attribute to specify additional menu name of Variable.
- Added State.IndexOfBehaviour method.
- Added NodeBehaviourList.IndexOf method.
- Added FlexiblePrimitiveBase class as the base class of the class that uses FlexiblePrimitiveType.
- Added ConstantRangeAttribute (FlexibleField version of Range attribute)
	- FlexibleInt, FlexibleFloat.
- Added HideSlotFields attribute to hide each DataSlot specific field
	- It is mainly used to hide the Type field of OutputSlotComponent and OutputSlotUnitObject.
- Added property to get / set access to each field on AgentController.
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
- Added Methods to CompositeBehaviouor
	- GetBeginIndex
	- GetNextIndex
	- GetInterruptIndex
- Added isRevaluation property to Decorator.

[CHANGES]

* Arbor Editor

- When creating a state rerouting node, it changed to inherit the color of the line.
- Calculator using FlexiblePrimitiveType.Random has been changed to always recalculate.
- Changed to auto-scroll behavior while dragging.

* Parameter Container

- Changed to show value label.

* AgentController

- When Animator is none, change the parameter name so that it can be edited with TextField.
	- (AnimatorParameterReference is changed as well)

* Built-in Behaviour

- Changed some built-in behavior fields to FlexibleField.
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
- Material changed behavior to use MaterialPropertyBlock.
	- TweenColor
	- TweenTextureOffset
- Changed each field of Tween behavior to cache at state start.

* Built-in Calculator

- Changed the title name to match AddBehaviorMenu.

* Built-in Decorator

- Changed to show the time progress bar only when reevaluating.
	- Cooldown
	- TimeLimit

* Scripts

- Changed ComponentParameterReference so that it can specify component parameters other than Parameter.Type.Component.
- Rename CalculatorSlot to DataSlot.
- Rename CalculatorBranch to DataBranch.
- Rename CalculatorBranchRerouteNode to DataBranchRerouteNode.
- Rename FlexibleType.Calculator to DataSlot.
- Rename FlexiblePrimitiveType.Calculator to DataSlot.
- Rename DataBranch.isVisible to showDataValue.

[OBSOLETES]

* Scripts

- Obsolete the creation of scripts by boo and javascript.
- Obsolete InputSlotAny(System.Type) constructor.
- Obsolete OutputSlotAny(System.Type) constructor.
- Obsolete AnyParameterReference.parameterType.
- Obsolete AnyParameterReference(System.Type).
- Obsolete ParameterContainer's old GetInt method etc.

[FIXES]

* Arbor Editor

- When Behavior Tree was selected, a separator was added at the bottom of the debug menu on the tool bar.
- Fixed wording of switching menu of show data value.
- Fixed that abstract class of behavior is enumerated in behavior addition window.
- Fix to update rectangle when automatic scrolling during rectangle selection drag.

Ver 3.1.3:

[FIXES]

* Editor

- Fixed an exception occurs when displaying Inspector when declaring CalculatorSlot in MonoBehaviour script.
- Fixed an issue where label of field name disappeared when declaring FlexibleField<T> with non-serializable type.

* Scripts

- Fixed that InputSlot<T> is not displayed in the script reference.
	- Renamed InputSlot class to InputSlotBase.
- Fixed that OutputSlot<T> is not displayed in the script reference.
	- Renamed OutputSlot class to OutputSlotBase.
- Fixed that FlexibleField<T> could only use class with Serializable attribute.
- Fixed that Variable<T> could only use class with Serializable attribute.
- Fixed that it was "not serializable" even if specifying a serializable type for Variable<T>.
- Fixed the Arbor script template so that it is not displayed in the AddComponent menu.
- Fixed the path of the AddComponent menu of Example script to "Arbor / Example".
- Fix to ignore when a type other than a subclass is specified in the field of CalculatorSlot with SlotTypeAttribute.
- Fix to constrain CalculatorSlot which can use SlotTypeAttribute to the following class.
	InputSlotComponent, InputSlotUnityObject, InputSlotAny, OutputSlotAny

Ver 3.1.2:

[FIXES]

* Arbor Editor

- Fixed unlimited recursion when the Unity object derived class with the System.Serializable attribute has a field that refers to itself.

Ver 3.1.1:

[ADDITION]

* Built-in StateBehaviour

- Added AgentWarpToPosition
- Added AgentWarpToTransform
- Added TransformSetPosition
- Added TransformSetRotation
- Added TransformSetScale
- Added TransformTranslate
- Added TransformRotate

* Built-in ActionBehaviour

- Added AgentWarpToPosition
- Added AgentWarpToTransform

* Built-in Calculator

- Added StringConcatCalculator
- Added StringJoinCalculator

* Scripts

- Added Warp method to AgentController.
- Added OnGraphPause, OnGraphResume, OnGraphStop callback to NodeBehaviour.

[FIXES]

* ArborFSM

- Fixed a problem that transition number does not increase if TransitionTiming.Immediate transition is made except State callback method.
- Fixed that the OnStateEnd method will not be called back when ArborFSM.Stop() is called.

* BehaviourTree

- Fixed that the OnEnd method will not be called back when BehaviourTree.Stop() is called.

* Built-in StateBehaviour

- Fixed not transitioning on completion when Tween's Duration is set to 0.

Ver 3.1.0:

[ADDITION]

* ArborEditor

- When the graph is not selected, a graph creation button and a button for opening a manual page are displayed.
- Added zoom of graph (Unity 2017.3.0f3 or later)
- Added capture of graph.
- Added graph creation button on toolbar.
- Added display of Arbor logo when opening graph.
	You can toggle in the setting window from the gear icon.
- Added update notification of AssetStore.

* ArborEditor extension

- Added underlayGUI callback which can customize the back side to ArborEditorWindow class.
- Added overlayGUI callback which can customize front side to ArborEditorWindow class.
- Added toolbarGUI callback which can customize toolbar to ArborEditorWindow class.

* ParameterContainer

- Add Variable to add user-defined type.
- Added VariableGeneratorWindow to create Variable definition script from template.

* AgentController

- Added MovementType field.
- Added MovementDivValue field.
- Added TurnType field.
- Changed to transfer movement value and rotation amount to Animator according to MovementType and TurnType.

* Built-in StateBehaviour

- Added AgentLookAtPosition to rotate AgentController in the direction of specified position.
- Added AgentLookAtTransform to rotate AgentController int the direction of specified Transform.
- Added SubStateMachineReference which executes prefabricated ArborFSM as a child graph.
- Added SubBehaviourTreeReference which executes prefabricated BehaviourTree as a child graph.
- Added SetActiveScene to activate the scene.
- Add IsActiveScene field to LoadLevel.
- Added Done transition to LoadLevel.

* Built-in ActionBehaviour

- Added AgentLookAtPosition to rotate AgentController in the direction of specified position.
- Added AgentLookAtTransform to rotate AgentController int the direction of specified Transform.
- Added SubStateMachineReference which executes prefabricated ArborFSM as a child graph.
- Added SubBehaviourTreeReference which executes prefabricated BehaviourTree as a child graph.
- Added display of elapsed time to Wait action.

* Built-in Decorator

- Added display of elapsed time to TimeLimit decorator.
- Added display of elapsed time to Cooldown decorator.

* Scripts

- Supports Assembly Definition (Unity 2017.3.0f3 or later)
	Following this support, the folder structure has also changed.
- Added rootGraph property to NodeGraph class.
- Added ToString method to NodeGraph class.
- Added GetName method to Node class.
- Added ToString method to Node class.
- Added InputSlotAny class which can specify input type.
- Added OutputSlotAny class witch can specify output type.
- Added AnyParameterReference class witch can specify the type of parameter to refer.
- Added FlexibleField<T> generic class version of Flexible type class.
- Added variableValue property to Parameter class.
- Added SetVariable method to Parameter class.
- Added GetVariable method to Parameter class.

[CHANGES]

* ArborEditor

- Change Grid button to gear icon, rename popup window displayed by pressing button to GraphSettings window to set other than grid.
- Move the toolbar language popup to the GraphSettings window.
- Changed to display the menu for opening asset store and manual page from the help button of the toolbar.
- Changed the highlight display to the easy-to-see design when mouse over the connection line.
- Change resizing of group nodes so that they can be dragged on each side.
- Change it so that multiple selection can be made by holding Ctrl or Shift in the side panel node list.
- When dragging the direction of the reroute node, press Esc key to change it so that it can be canceled.

* Built-in StateBehaviour

- Change Additive field of LoadLevel to LoadSceneMode field.
- Change the Seconds field of TimeTransition to FlexibleFloat type.

* Scripts

- Changed to use reference types commonly used in FlexibleField related class.
- Property such as Parameter.intValue etc.
	Changed to call onChanged when set.
- Added set to Parameter.value property.

[OBSOLETES]  

* Scripts

- Changed Parameter.OnChanged method to Obsolete.
	OnChanged is now internally called back when changing Parameter.intValue etc, so calling is no longer necessary.
- Change AddCalculatorMenu attribute to Obsolete.
	Changed to use AddBehaviourMenu attribute in common.
- Change BuiltInCalculator attribute to Obsolete.
	Changed to use BuiltInBehaviour attribute in common.
	Also, since the BuiltInBehaviour attribute is an attribute for built-in behavior, there is no problem if you do not use it otherwise.
- Change CalculatorHelp attribute to Obsolete.
	Changed to use BehaviourHelp attribute in common.
- Change CalculatorTitle attribute to Obsolete.
	Changed to use BehaviourTitle attribute in common.

[FIXES]

* ArborEditor

- Fixed that active display was kept on ArborEditor even when BehaviourTree ended.
- Fixed height of Calculator type field of FlexibleGameObject.
- Fixed that the graph name input field in the side panel was kept in focus even if you clicked anything other than the input field.
- Fixed that pressing the Esc key while dragging a connection line such as StateLink or CalculatorSlot left line display during dragging.
- Fixed that the appearance of the header style of the side panel was changed depending on the version of Unity.
- Fixed that editing such as cutting and pasting of text could not be done with FlexibleString with ConstantMultilineAttribute.
- Fixed occurrence of NullReferenceException when starting playing or switching scenes with docked ArborEditor window hidden.
- Fixed incorrect display position of connection line to node outside screen when exiting play mode.
- Fixed that node name was not copied when copying Action node.
- Fixed that node name was not copied when copying Composite node.
- Fixed that grid snap was not working when pasting or duplicating node.
- Fixed that the connection line did not disappear even if State was deleted when State transition source is a reroute node.
- Fixed that the connection line will not be redrawn immediately if you redo the state connecting StateLink after deleting it.
- Fixed Undo / Redo of node selection.
- Fixed that memory leak occurred when repeating Undo / Redo of node creation and deletion.
- Fixed bug when performing graph selection Undo / Redo.
- Fixed to prevent Frame Selected when node was not selected.

* ArborFSM

- Fixed that NullReferenceException occurs when doing RemoveComponent of ArborFSM in Unity 2018.1 or later.
- When dragging and dropping the prefabricated ArborFSM onto the scene window, the component used inside the graph is displayed in the inspector.

* BehaviourTree

- Fixed occurrence of NullReferenceException if interruption judgment is made at the timing when the current node becomes Root.
- Fixed that NullReferenceException occurs when doing RemoveComponent of BehaviourTree in Unity 2018.1 or later.
- When dragging and dropping the prefabricated BehaviourTree onto the scene window, the component used inside the graph is displayed in the inspector.

* AgentController

- Fixed a bug that referenced Transform of AgentController itself.
- Fix to initialize AgentController with Awake.

* Built-in StateBehaviour

- Fix SubStateMachine UpdateType to Manual
	Changed to handle at the appropriate timing by UpdateType of route graph.
- Fixed that ArborFSM no longer appears in the inspector when adding SubBehaviourTree.

* Built-in ActionBehaviour

- Fixed Wait's Seconds recalculating every frame.

* Built-in Decorator

- Fixed TimeLimit's Seconds recalculating every frame.
- Fixed Cooldown's Seconds recalculating every frame.

* Scripts

- Fix State.transitionCount to uint.
- Fix to prevent State.transitionCount from exceeding uint.MaxValue.
- Fix StateLink.transitionCount to uint.
- Fixed StateLink.transitionCount not to exceed uint.MaxValue.

* Others

- Fixed that it took time to start when play started immediately after script compilation.
- Fixed error in Unity 2018.2.0 Beta version.

Ver 3.0.2:

[ADDITION]

* Built-in StateBehaviour

- Add ForceMode and Space fields to AddForceRigidbody.
- Add Space field to AddVelocityRigidbody.
- Add Space field to SetVelocityRigidbody.
- Add ForceMode and Space fields to AddForceRigidbody2D.
- Add Space field to AddVelocityRigidbody2D.
- Add Space field to SetVelocityRigidbody2D.
- Added StoppingDistance field to AgentMoveOnWaypoint.

* Built-in ActionBehaviour

- Added StoppingDistance field to AgentMoveOnWaypoint.

[FIXES]

* ArborEditor

- Fixed that connection slots were not highlighted in inheritance relationship while dragging the calculator slots.

* Component

- Fixed that AgentControllor 's isDone might not become true due to calculation error of float.

* Built-in StateBehaviour

- Fix SubStateMachine's UpdateType to Manual.

Ver 3.0.1:

[FIXES]

* Arbor Editor

- Fixed an exception occurs when deleting the node graph after closing the Arbor Editor window.
- Fixed that the rename frame was not displayed when creating an action node or a composite node without docking the Arbor Editor window.
- Fixed an error occurred in ArborEditor if a DLL that failed to load existed.

* Built-in ActionBehaviour

- Fixed that there was no reference of DestroyGameObject.

Ver 3.0.0:

[New: Behavior Tree]

* Overview

As a new function, Behaviour Tree which can combine behaviors while visualizing priority by tree structure has been added.

There are RootNode which becomes active first, CompositeNode which decides execution order of child nodes, and ActionNode which specifies action.

In ActionNode, you can set a script ActionBehavior which describes behavior.
ActionBehaviour can be customized as well as ArborFSM's StateBehaviour.

For CompositeNode and ActionNode you can also add a script Decorator which checks the condition to execute and repeats it.
Customization is also possible here.

Besides, flexible AI can be created by Service script executed while the node is active.

Also, as with ArborFSM, data can be exchanged between nodes by using calculator nodes and calculator slots.

* Component
- Added BehaviourTree component.

* Built-in CompositeBehaviour
- Added Selector.
- Added Sequencer.

* Built-in ActionBehaviour
- Added Wait.
- Added PlaySound.
- Added PlaySoundAtPoint.
- Added PlaySoundAtTransform.
- Added StopSound.
- Added SubStateMachine.
- Added SubBehaviourTree.
- Added InstantiateGameObject.
- Added DestroyGameObject.
- Added ActivateGameObject.
- Added AgentPatrol.
- Added AgentMoveToPosition.
- Added AgentMoveToTransform.
- Added AgentMoveOnWaypoint.
- Added AgentEscapeFromPosition.
- Added AgentEspaceFromTransform.
- Added AgentStop.

* Built-in Decorator
- Added Loop.
- Added SetResult.
- Added InvertResult.
- Added ParameterCheck.
- Added CalculatorCheck.
- Added ParameterConditionalLoop.
- Added CalculatorConditionLoop.
- Added TimeLimit.
- Added Cooldown.

* Script
- Added CompositeBehaviour to control execution of child nodes.
- Added ActionBehaviour to execute action.
- Added Decorator to decorate nodes.
- Added Service to run while the node is active.

[ADDITION]

* Arbor Editor
- Implement hierarchy of graphs.
- Added Graph item to the side panel.
- Added menus when dropping on nothing when StateLink is dragging.
- Added a reroute node of the StateLink connection line.
- Added a reroute node of CalculatorBranch connection line.
- Added to log to Console by clicking the value of CalculatorBranch.
- Adding a function that does not move the nodes in the group when moving the group node while holding down the Alt(Option on Mac) key.

* ArborFSM
- Flag to play at start Added Play On Start field.
- Added Update Settings field to set update interval etc.

* ParameterContainer
- Added type specification of Component parameter.
- Added Color parameter.

* Built-in StateBehaviour
- Added SubStateMachine.
- Added EndStateMachine.
- Added SubBehaviourTree.
- Added Center Type field to AgentPatrol.
- Added Center Transform field to AgentPatrol.
- Added Center Position field to AgentPatrol.
- Added Is Check Tag field to RaycastTransition.
- Added Tag field to RaycastTransition.

* Script
- Added base class NodeGraph for handling graphs.
- Added interface INodeBehaviourContainer to be used when Node stores NodeBehaviour.
- Added interface INodeGraphContainer to be used when NodeBehaviors store child graphs.
- Added OnCreated method called when creating NodeBehaviour.
- Added OnPreDestroy method called before NodeBehaviour discard.
- Added Play and Stop methods to ArborFSMInternal.
- Added Pause and Resume method to ArborFSMInternal.
- Added playState property to ArborFSMInternal.
- Added TimeUtility.CurrentTime method to return current time from TimeType.
- Added GetClosestParam method to Bezier2D.
- Added GetClosestPoint method to Bezier2D.
- Added SetStartPoint method to Bezier 2D.
- Added SetEndPoint method to Bezier 2D.
- Added ComponentParameterReference so that the type of Component referenced by SlotTypeAttribute can be specified.

[CHANGES]

* Arbor Editor
- Renamed state list of toolbar to side panel.
- Renamed state list of side panel to node list.
- When copying and pasting the state, when copying source and copying destination were the same ArborFSM, changed to paste with StateLink connected.
- When copying and pasting the state, change StateLink so that StateLink will stay connected if the state to which StateLink is connected is also pasted node.
- Change color when mouse over of StateLink's line.
- Changed to display the menu even when right-clicking the title bar of StateBehaviour.
- Change the way to display the value of CalculatorBranch during execution by mouse over the line or checking "Always display value" from the right click menu.
- Change the design of the current state being executed.
- Adjust scrolling to move to the selected node.

* Built-in StateBehaviour
- Agent MoveOnWaypoint Changed to move to the current target point at the start and move the target point to the next after the movement is completed.

* Script
- ArborFSMInternal changed to inherit from NodeGraph.
- Remove the fsmName of ArborFSMInternal (the use of graphName to NodeGraph).
- Changed FindFSM and FindFSMs of ArborFSM to Obsolete (use FindGraph and FindGraphs of NodeGraph).
- Changed stateID of StateBehaviour to Obsolete (use nodeID).
- Changed the graph referenced from Node and NodeBehaviour from ArborFSMInternal to NodeGraph.
- Changed to manage CalculatorNode by NodeGraph.
- Changed to manage GroupNode with NodeGraph.
- Changed to manage CommentNode with NodeGraph.
- Changed to manage ClaculatorBranch by NodeGraph.
- Change the stateMachine field of CalculatorSlot to the nodeGraph field.
- Move the stateMachine property of NodeBehaviour to StateBehaviour.
- Changed lineEnable of StateLink to NonSerialized.
- Delete StateLink's lineStart and add a bezier field.
- Move the TimeType in the TimeTransition class to the Arbor namespace.
- Changed the built-in StateBehaviour namespace to Arbor.StateMachine.StateBehaviours.
- Changed to specify Parameter to be referenced by SlotTypeAttribute specified by FlexibleComponent.
- Changed so that you can use the RequiresContentRepaint method of the Editor class when redrawing is required.

* Other
- Dragged from NodeGraph from Inspector to Hierarchy so that it can not be moved.
- Move built-in NodeBehaviour related scripts to the BuiltInBehaviours folder.

[FIXES]

* Arbor Editor
- Fixed Copy node disappearing when ArborFSM Copy Component is executed after copying node.
- Fixed that StackOverflowException occurred when repeating transition by TransitionTiming.Immediate.
- Fixed that it did not stop if you wanted to transition by TransitionTiming.Immediate even if a breakpoint was set in the state.
- Fixed an exception occurred when entering search word during hierarchical animation in AddBehaviourMenu window and AddCalculatorMenu window.
- Fixed that Arbor Editor reference does not return when Unode of Remove Component of NodeGraph.
- Fixed so that menu of graph is not displayed when right clicking in node.
- Fix to call OnStateAwake and OnStateBegin when behaviourEnabled is switched during execution.
- Fix to call OnStateAwake and OnStateBegin when StateBehaviour was added during execution.
- Fixed a log of "Removed unparented EditorWindow while reading window layout" appearing in TypePopupWindow when starting Unity.
- Fix to always do redrawing during execution only when necessary.
- Fix to grid snap when creating nodes.
- Fixed display of node blurred when size of graph area was changed by node creation etc.

* Script
- Fixed that EachField enumerated duplicate public and protected fields of base class.

* Other
- Fixed that NodeBehaviour remains internally when Reset from Inspector.
- Fixed that Calculator remained internally when deleting ArborFSM component.

Ver 2.2.3:

* Arbor Editor
- Fix : Fixed that node shortcuts could be used while renaming nodes.
- Fix : When changing the order of ParameterContainer 's parameters, an exception that occurred when referring to that parameter was corrected.

Ver 2.2.2:

* Arbor Editor
- Add : Added so that nodes and objects using deleted StateBehaviour and Calculator scripts can be deleted.
- Fix : Fixed an exception (ArgumentNullException) occurred in the Arbor Editor window when deleting StateBehaviour and Calculator scripts used by ArborFSM.

* Other
- Change : Raised Unity's minimum action version to 5.4.0f3.

Ver 2.2.1:

* Arbor Editor
- Change : FlexibleString's Constant indication back.
- Fix : Fixed occurrence of an exception (NullReferenceException: SerializedObject of SerializedProperty has been Disposed.) When playing on the Unity editor is open with Arbor Editor open.
- Fix : Fixed that Label of Graph does not change even when switching languages.

* Component
- Add : Long added to the parameters that can be used in ParameterContainer.
- Change : Changed so that parameters can be rearranged by ParameterContainer.
- Change : Display parameter type in ParameterContainer.

* Built in Calculator
- Add : Added LongAddCalculator
- Add : Added LongSubCalculator
- Add : Added LongMulCalculator
- Add : Added LongDivCalculator
- Add : Added LongNegativeCalculator
- Add : Added LongCompareCalculator
- Add : Added LongToFloatCalculator
- Add : Added FloatToLongCalculator

* Script
- Add : Added ConstantMultilineAttribute which makes multiple lines of FlexibleString Constant display.
- Add : Added FlexibleLong, LongParameterReference, InputSlotLong, OutputSlotLong along with the addition of long type parameter.
- Fix : Fixed load was being applied by type enumeration processing at the beginning of play on Unity editor.

Ver 2.2.0:

* Arbor Editor
- Add : Added group node.
- Add : Added comments for each node.
- Add : Added node cutout.
- Add : Added items for cutting, copying, duplicating, deleting nodes in node context menu.
- Add : Transition Timing icon display on StateLink button.
- Add : Copy Component of ArborFSM Inspector supports copying including internal components.
- Change : Editor design change.
- Change : Changed to display state name input field with double click.
- Change : Changed to sort the state list in order of type (start state -> normal state -> resident state).
- Change : Change Immediate Transition of StateLinkSettingWindow to Transition Timing.
- Change : Added type specification to OutputSlotComponent.
- Change : Change the display when Constant of FlexibleString to TextArea.
- Change : Corresponds to scroll at fixed time intervals while scrolling with dragging.
- Change : Adjust the maximum amount of movement during drag scrolling.
- Fix : Fixed that node position shifted when scrolling while dragging a node
- Fix : Correct that vertex number error occurs when CalculatorBranch line is long.
- Fix : Fixed that vertical margin is displayed when StateLinkSettingWindow is displayed at the screen edge.
- Fix : Fixed that lines are hidden when StateLink is reconnected to the same state.
- Fix : Fixed that StateBehaviour appears in the inspector when Apply to the Prefab of ArborFSM object during execution.
- Fix : Fixed that StateBehaviour of the current state is saved in Prefab while it is in the effective state when Apply to the Prefab of ArborFSM object during execution.
- Fix : Corrected the connection when changing Size in Behavior which has CalculatorSlot as an array.
- Fix : Fixed that other nodes are not displayed for a moment when node is deleted.
- Other : Optimize display of dot line of CalculatorBranch.

* Built in Behaviour
- Add : Added AgentStop.
- Add : Added AnimatorCrossFade.
- Add : Added AnimatorSetLayerWeight.
- Add : Added BackToStartState.
- Add : Added ActivateBehaviour.
- Add : Added ActivateRenderer.
- Add : Added ActivateCollider.
- Add : Added ChangeTimingUpdate parameter to UISetSlider, UISetText, UISetToggle.
- Change : Added flag to whether LookAtGameObject uses each coordinate component of Target transform.
- Change : Added flag to determine whether to stop Agent when leaving state to Agent system.
- Change : Added reference URL for format specification to the format document of UITextFromParameter.
- Change : Built-in behavior referring to Component corresponds to FlexibleComponent.
- Change : Move UISetSliderFromParameter and UISetToggleFromParameter to Lagacy by FlexibleComponent correspondence of UISetSlider and UISetToggle.
- Fix : Fixed that exceptions are generated after transition of scenes with behavior being processed when Parameter is changed via GlobalParameterContainer (UISetTextFromParameter, UISetToggleFromParameter, UISetSliderFromParameter, ParameterTransition).
- Fix : Fixed that there was no UISetImage reference.

* Built in Calculator
- Add : Added GameObjectGetComponentCalculator.
- Fix : Fixed an exception occurred after the scene transition in the Calculator processing when Parameter was changed via GlobalParameterContainer.

* Component
- Add : Added various parameters for Animator setting to AgentController.
- Add : Added Waypoint component.
- Add : Added Component to parameters available in ParameterContainer.
- Change : Change Animator specification of AgentController so that it is unified for each parameter.

* Script
- Add : Add parameter reference class for each Animator type.
- Add : Addition of OnStateUpdate callback called during Update in order of StateBehaviour.
- Add : Addition of OnStateLateUpdate callback called during LateUpdate in order of StateBehaviour.
- Add : InputSlotUnityObject, OutputSlotUnityObject added.
- Add : Added FlexibleComponent.
- Add : Added SlotTyeAttribute which can specify type with CalculatorSlot or FlexibleCompoment.
- Add : ComponentParameterReference added.
- Add : Create a NodeBehaviour class that summarizes the intersection of StateBehaviour and Calculator.
- Add : Added interface, INodeBehaviourSerializationCallbackReceiver, to describe the processing at serialization of NodeBehaviour.
- Add : Added type and parameter property to various Flexible classes.
- Change : The ID of each node is unified to Node.nodeID.
- Change : Added ToString method to Parameter class.
- Change : Added updatedTime to CalculatorBranch.
- Change : Addition of isUsed and updatedTime to InputSlot.
- Change : Change transition timing specification in Transition method to TransitionTiming.
- Change : Change CalculatorSlot.position to NonSerialized.
- Change : Add using System.Collections.Generic; and AddComponentMenu ("") to the template.
- Fix : Fixed it because we did not reference the field of base class in EachField.

Ver 2.1.8:

* Arbor Editor
- Fix : Fixed that the drag process will not stop when the node is not displayed by scrolling while dragging StateLink or CalculatorSlot.

Ver 2.1.7:

* Script
- Change : When disabled ArborFSM's Transition method is called, transition is delayed until it becomes enable even if immediateTransition is set to true.

Ver 2.1.6:

* Arbor Editor
- Fix : Fixed a bug that exception occurs with the start of play when you add a StateBehaviour to Prefab instance of ArborFSM.

Ver 2.1.5:

* Arbor Editor
- Fix: Speed up the Arbor Editor window.

* Built in Behaviour
- Fix : Fix not to display RandomTransition on Inspector's Add Component menu.

Ver 2.1.4:

* Arbor Editor
- Fix : Fixed that a warning is displayed at the beginning of playing by copying a node.
- Fix : Fixed a bug that the node will be restored at the start of playing if deleting a node only from Prefabed instance.

* Script
- Add : Added method to obtain index of various nodes in ArborFSMInternal: GetStateIndex(), GetCommentIndex(), GetCalculatorIndex()

Ver 2.1.3:

* Arbor Editor
- Fix : Fixed exception which appears when pressing Apply button of Prefab instance attaching ArborFSM.

Ver 2.1.2:

* Arbor Editor
- Add : Added a function that can transition to arbitrary state on ArborEditor window during play.
- Fix : Fixed that ArborEditor window does not display properly when an exception occurs in StateBehaviour and Calculator Editor.
- Fix : Fixed exception that occurred when StateBehaviour and Calculator script could not be loaded.
- Fix : Fixed an exception "NullReferenceException: SerializedObject of SerializedProperty has been disposed." When ArborEditor is displayed.
- Fix : Fixed that the width of the state list becomes too narrow when the width of the ArborEditor window becomes narrower.

* Built in Behaviour
- Change : Added OnTweenBegin method of callback for initialization at the start of Tween.
- Change : Rename the Event parameter of SendEventGameObject to OnStateBegin.
- Add : Add OnStateAwake event and OnStateEnd event to SendEventGameObject.

* Script
- Add : Added Get / Set method of all types handled by ParameterContainer.
- Add : Added GetParamID method to ParameterContainer.
- Add : Added a method that can also perform Get / Set method of ParameterContainer from ID.
- Fix : When SendTrigger was used during transition processing, it was modified to send Trigger after completion of transition processing.

Ver 2.1.1:

* Arbor Editor
- Change : Move breakpoint and state count display out of frame
- Fix : Fixed that Copy & Paste could not be done with String of ParameterContainer.
- Fix : Fix to delete CalculatorBranch when data slot is deleted from script

Ver 2.1.0:

* Arbor Editor
- Add : Added a toggle to lock so as not to switch even when GameObject is selected.
- Add : Implemented to be able to rearrange by dragging the title bar of StateBehaviour.
- Add : Implemented so that StateBehaviour can be inserted at arbitrary position by drag & drop.
- Add : Implemented so that you can set breakpoints in State.
- Add : Implemented to display the number of times State and StateLink passed during execution.
- Add : Implemented to highlight StateLink that passed immediately during execution.
- Add : Implemented to display the value of CalculaterBranch during execution.
- Add : Opens the help page from the built-in component's help button.
- Add : Opens the help page from the help button of the built-in Calculator.
- Add : Change the line color according to the type of CalculatorBranch.
- Fix : ArborFSM Fixed no longer be able to access the data from the input-output slot when you move to another GameObject.
- Fix : The graph display area of Arbor Editor is fixed.
- Fix : Fixed that Arbor Editor's graphic display blurred when automatically scrolling to the selected state, such as when selecting from the state list.
- Add : Add icon to ArborEditor window

* Built in Behaviour
- Change : Correspond to output GameObject found by FindGameObject, FindWithTagGameObject to the operation node.
- Add : Added RandomTransition.
- Change : TimeType specification added to TimeTransition.
- Fix : Fix caching with reference to Flexible component.
- Fix : Fixed an error when decreasing the size of the array on the editor with Behavior which has StateLink in the array.

* Script
- Change : Change OnStateTrigger to virtual function of StateBehaviour.
- Fix : Fix to prevent errors when null is passed to AgentController.Follow and Escape.

* Other
- Change: Updated reference site.
- Change: Raise Unity's lowest action version to 5.3.0f4.

Ver 2.0.10:

* Arbor Editor
- Change : When selecting GameObject, Arbor Editor also works in conjunction so that display is switched.
- Fix : Fixed an error when creating a new comment.
- Fix : Fixed an error when starting play when copying node.
- Fix : Fixed that you can not paste after copying the node and starting playing once.
- Fix : Fix copy of Calculator node.
- Fix : Fixed processing when copying & pasting or duplicating StateBehaviour or Calculator with CalculatorSlot.

Ver 2.0.9:

* Arbor Editor
- Fix: Fixed an error when opening ArborEditor with Unity 5.6.
- Fix: Speed up the Arbor Editor window.

* Built in Behaviour
- Change : Change Bool of CalculatorTransition to compare two Bool values.

* Scripts
- Change : Add State.behaviourCount and GetBehaviourFromIndex. Deprecated State.behaviours.
- Change : ArborFSMInternal.stateCount and GetStateFromIndex added. Deprecated ArborFSMInternal.states.
- Change : Added ArborFSMInternal.commentCount and GetCommentFromIndex. Deprecated ArborFSMInternal.comments.
- Change : ArborFSMInternal.calculatorCount and GetCalculatorFromIndex added. Deprecated ArborFSMInternal.calculators.
- Change : ArborFSMInternal.calculatorBranchCount and GetCalculatorBranchFromIndex added. Deprecated ArborFSMInternal.calculatorBranchies.

Ver 2.0.8:

* Arbor Editor
- Fix : Fixed an error displayed when copying Node or StateBehaviour in Arbor Editor after Unity 5.3.4 or later.
- Change : Change Script Execution Order so that ArborFSM is executed first.

Ver 2.0.7:

* Arbor Editor
- Add : Added OutputSlotString and InputSlotString
- Add : Added FlexibleString
- Add : Added string to ParameterContainer
- Add : Implement processing with string parameter in CalcParameter
- Add : Implement transitions with string parameters in ParameterTransition
- Add : Implement text setting from string to UISetTextFromParameter.
- Fix : Fixed that slots do not display correctly in Arbor Editor when creating customized class of OutputSlot / InputSlot

Ver 2.0.6:

* Arbor Editor
- Fix : Fixes the Undo / Redo when deleting a node.
- Fix : Fixes the Undo / Redo when deleting a StateBehaviour.

Ver 2.0.5:

* Arbor Editor
- Fix : Fix to repaint the ArborEditor window when you add a calculator node and state behaviour.
- Fix : Fixed the ArborEditor namespace RectUtility.
- Fix : Fix a template for Boo.

* Built in Behaviour
- Change: change the parameters of the Tween series to be able to receive from the calculator node.

Ver 2.0.4:

* Arbor Editor
- Add : Adding to call the OnStateAwake() when you first entered the State.
- Fix : Fix a menu which can be moved to the transition destination when you right-click a transition arrow to display in control + click on the Mac.
- Fix : Fix the error in the Unity5.5.0Beta.

Ver 2.0.3:
* Arbor Editor
- Fix: Fixed a warning that exits at Unity5.4.0Beta
- Fix: Modify the state is not generated in the mouse position at the time of the state of the paste or duplication.

Ver 2.0.2:
* Arbor Editor
- Fix: Unity5.3.0 Fixed When you play start still selected ArborFSM object StateBehaviour from being removed on the later of the Unity editor.

* Built in Behaviour
- Add: corresponding to be able to set the Additive property to Scene / LoadLevel.
- Add: Scene / UnloadLevel add (Unity5.2 or later).
- Fix: Fixed a Application.LoadLevel warning exiting at Unity5.3.0 later Scene / LoadLevel.

Ver 2.0.1:
* Arbor Editor
- Change: reduce the amount of heap memory.
- Fix: Fixed editor management for the object every time you compile had been increasing.

* Built in Behaviour
- Change: Renamed the Audio / PlaySoundAtPoint in Audio / PlaySoundAtTransform.
- Add: Adds the specified AudioMixerGroup and SpatialBlend in Audio / PlaySoundAtTransform.
- Add: add an Audio / PlaySoundAtPoint of new coordinates specified.

Ver 2.0.0:
* Arbor Editor
- Add : Add calculaltor node.
- Add: corresponding to be able to hold the Vector2 in ParameterContainer.
- Add: corresponding to be able to hold the Vector3 in ParameterContainer.
- Add: corresponding to be able to hold a Quaternion in ParameterContainer.
- Add: corresponding to be able to hold the Rect in ParameterContainer.
- Add: corresponding to be able to hold the Bounds in ParameterContainer.
- Add: corresponding to be able to hold the Transform in ParameterContainer.
- Add: corresponding to be able to hold the RectTransform in ParameterContainer.
- Add: corresponding to be able to hold the Rigidbody in ParameterContainer.
- Add: corresponding to be able to hold the Rigidbody2D in ParameterContainer.

* Built in Behaviour
- Add : Transition/Physics/RaycastTransition
- Add : Transition/Physics2D/Raycast2DTransition
- Add : Transition/CalculatorTransition
- Add: Add the output of GameObject generated in InstantiateGameObject
- Add: Add the output of the other Collision hitting the OnCollisionEnterTransition
- Add: Add the output of the other Collision hitting the OnCollisionExitTransition
- Add: Add the output of the other Collision hitting the OnCollisionStayTransition
- Add: Add the output of the other Collider, which hit the OnTriggerEnterTransition
- Add: Add the output of the other Collider, which hit the OnTriggerExitTransition
- Add: Add the output of the other Collider, which hit the OnTriggerStayTransition
- Add: Add the output of the other Collision2D hitting the OnCollisionEnter2DTransition
- Add: Add the output of the other Collision2D hitting the OnCollisionExit2DTransition
- Add: Add the output of the other Collision2D hitting the OnCollisionStayT2Dransition
- Add: Add the output of the other Collider2D hitting the OnTriggerEnter2DTransition
- Add: Add the output of the other Collider2D hitting the OnTriggerExit2DTransition
- Add: Add the output of the other Collider2D hitting the OnTriggerStayT2Dransition
- Change: AgentEscape the corresponding to FlexibleTransform.
- Change: AgentFllow the corresponding to FlexibleTransform.
- Change: PlaySoundAtPoint the corresponding to FlexibleTransform.
- Change: InstantiateGameObject the corresponding to FlexibleTransform.
- Change: LookAtGameObject the corresponding to FlexibleTransform.
- Change: AddForceRigidbody the corresponding to FlexibleRigidbody.
- Change: AddVelocityRigidbody the corresponding to FlexibleRigidbody.
- Change: SetVelocityRigidbody the corresponding to FlexibleRigidbody.
- Change: AddForceRigidbody2D the corresponding to FlexibleRigidbody2D.
- Change: AddVelocityRigidbody2D the corresponding to FlexibleRigidbody2D.
- Change: SetVelocityRigidbody2D the corresponding to FlexibleRigidbody2D.

* Built in Calculator
- Add: Calculator additional Bool
- Add: Calculator additional Bounds
- Add: Calculator additional Collider
- Add: Calculator additional Collider2D
- Add: Calculator additional Collision
- Add: Calculator additional Collision2D
- Add: Calculator additional Component
- Add: Calculator additional Float
- Add: Calculator additional Int
- Add: Calculator additional Mathf
- Add: Calculator additional Quaternion
- Add: Calculator additional RaycastHit
- Add: Calculator additional RaycastHit2D
- Add: Calculator additional Rect
- Add: Calculator additional RectTransform
- Add: Calculator additional Rigidbody
- Add: Calculator additional Rigidbody2D
- Add: Calculator additional Transform
- Add: Calculator additional Vector2
- Add: Calculator additional Vector3

* Scripts
- Add: FlexibleBounds implementation
- Add: FlexibleQuaternion implementation
- Add: FlexibleRect implementation
- Add: FlexibleRectTransform implementation
- Add: FlexibleRigidbody implementation
- Add: FlexibleRigidbody2D implementation
- Add: FlexibleTransform implementation
- Add: FlexibleVector2 implementation
- Add: FlexibleVector3 implementation

Ver 1.7.7p2:
* Arbor Editor
- Fix : Fixed an error that exits at Unity5.2.1 later.

Ver 1.7.7p1:
* Arbor Editor
- Fix : Fix for creation and deletion of the state and the comment could not be Undo.

Ver 1.7.7:
* Arbor Editor
- Add : Corresponding to be able to hold a GameObject in ParameterContainer.
- Change : Change to be able to transition to their own state.
- Change : Change the background of behavior.
- Change : Change the background of ListGUI.
- Change : Change the comment node to resize depending on the contents.
- Fix : Bug fixes around Undo
- Fix : Fixed resident state could be set to the start state.
- Other : Corresponding to save the settings, such as the grid for each major version of Unity instead of every project.

* Built in Behaviour
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
- Add : Added to allow relative specified in UITweenPosition.
- Add : Added to allow relative specified in UITweenSize.
- Change : Corresponding value of BroadcastMessageGameObject to use such FlexibleInt.
- Change : Corresponding value of CalcAnimatorParameter to use such FlexibleInt.
- Change : Corresponding value of CalcParameter to use such FlexibleInt.
- Change : Corresponding value of ParameterTransition to use such FlexibleInt.
- Change : Corresponding value of SendMessageGameObject to use such FlexibleInt.
- Change : Corresponding value of SendMessageUpwardsGameObject to use such FlexibleInt.
- Change : The corresponding AgentEscape to ArborGameObject.
- Change : The corresponding AgentFllow to ArborGameObject.
- Change : The corresponding ActivateGameObject to FlexibleGameObject.
- Change : The corresponding DestroyGameObject to FlexibleGameObject.
- Change : The corresponding LookatGameObject to FlexibleGameObject.
- Change : The corresponding BroadcastTrigger to FlexibleGameObject.
- Change : The corresponding SendTriggerGameObject to FlexibleGameObject.
- Change : The corresponding SendTriggerUpwards to FlexibleGameObject.
- Change : Corresponding to be able to store the object that was generated by the InstantiateGameObject the parameter.

* Script
- Add : FlexibleInt implementation
- Add : FlexibleFloat implementation
- Add : FlexibleBool implementation
- Add : FlexibleGameObject implementation
- Add : Corresponding to use the ContextMenu.

* Other
- Change : Parameter related to move to Core folder and the Internal folder.
- Other : Component to the icon set.

Ver 1.7.6:
* Arbor Editor
- Add : The name setting adds to StateLink.
- Add : Add immediate transition flag to StateLink.
- Fix : Fixed search string in the behavior added was not able to save.
- Other : When you open the behavior added, corresponding as focus moves to the search bar.
- Other : In order of at Add Behaviour, adjusted so that the group comes first.

* Component
- Add : GlobalParameterContainer

* Built int Behaviour
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
- Add : Add to display a progress bar the current time to TimeTransition.
- Add : It added to allow transition at the time of Tween end.
- Add : Added to allow relative specified in TweenPosition.
- Add : Added to allow relative specified in TweenRotation.
- Add : Added to allow relative specified in TweenScale.
- Add : Added to allow relative specified in TweenRigidbodyPosition.
- Add : Added to allow relative specified in TweenRigidbodyRotation.
- Fix : Fixed OnTriggerExit2DDestroy of was in Collision.
- Fix : Fixed floatValue of had become int of CalcAnimatorParameter.
- Fix : Fixed floatValue of had become int of CalcParameter.
- Fix : Fixed floatValue of had become int of ParameterTransition.
- Other : Renamed SetRigidbodyVelocity to SetVelocityRigidbody.
- Other : Renamed SetRigidbody2DVelocity to SetVelocityRigidbody2D.

* Script
- Add : Corresponding to prevent modification of the immediate transition flag in FixedImmediateTransition attribute.

* Other
- Add : Sample additional GlobalParameterContainer as Example9.
- Fix : Modify because Coin has been added to the Tags.

Ver 1.7.5:
* Arbor Editor
- Fix: Fixed there are times when the grid is not displayed correctly.
- Other: support to be able to resize the width of the state list.

* Built in Behaviour
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
- Add: Add in a way that allows you to specify the initial Transform at the time of generation in InstantiateGameObject.
- Fix: Fixed did not work properly in the case of type Bool in CalcParameter.
- Fix: modified to not bother to specify the person to call in SendEventGameObject.

* Script
- Add: The value property added to the Parameter.
- Add: IntParameterReference added.
- Add: FloatParameterReference added.
- Add: BoolParameterReference added.

* Other
- Add: add from the Hierarchy of the Create button to make the ArborFSM with GameObject.
- Add: add from the Hierarchy of the Create button to make the ParameterContainer with GameObject.
- Add: add from the Hierarchy of the Create button to make the AgentController with GameObject.
- Add: coin pusher game add as Example7.
- Add: sample additional EventSystem as Example8.
- Other: folder organization.

Ver 1.7.4:
- Add: Agent system Behaviour added.
- Add: uGUI system Behaviour added.
- Add: uGUI system Tween added.
- Add: SendEventGameObject added.
- Add: The pass-by-value function added to the SendMessageGameObject.
- Fix: AnimatorParameterReference of reference is to Fixed get an error when that did not refer to a AnimatorController.
- Other: Pull up on the Unity minimum operating version to 4.6.7f1 due to uGUI correspondence.

Ver 1.7.3:
- Add: OnMouse system Transition add
- Fix: move when the scroll position correction to the selected state
- Other: modified to sort the state list by name.
- Other: Arbor change to be able to place the infinite state also to the upper left of the Editor.
- Other: to renew the manual site.

Ver 1.7.2:
- Add: Add a comment node in ArborEditor.
- Add: corresponding to be able to search at the time of behavior added.
- Add: CalcAnimatorParameter added.
- Add: AnimatorStateTransition added.
- Add: add to be able to move to a transition source and a transition destination in the right-click on the transition line.
- Fix: Prefab source to the Fixed not correctly added to the Prefab destination and behavior added.
- Other: Renamed the ForceTransition to GoToTransition.
- Other: change so as not to omit the name of the built-in Behaviour that is displayed in the behavior added.
- Other: change so as not to display the built-in Behaviour to Add Component.

Ver 1.7.1:
- Add: Add the state list.
- Add: Add PropertyDrawer of ParamneterReference.
- Add: Add GUI, the ListGUI for the list that can be deleted elements.
- Fix: Fixed boolValue of had become int of CalcParameter.

Ver 1.7.0;
- Add: parameter container.
- Fix: OnStateBegin () If you have state transitions, fix than it so as not to run the Behaviour under.

Ver 1.6.3f1:
- Fixed an error that exits at Unity5 RC3.
- Unity5 RC3 by the corresponding Renamed OnStateEnter / OnStateExit to OnStateBegin / OnStateEnd.

Ver 1.6.3:
- Add the force flag in Transition. you can do to transition on the spot at the time of the call to be to true.
- Embedded documentation comments to the source code.
- Place the script reference to Assets / Arbor / Docs.
  Please open the index.html Unzip.

Ver 1.6.2:
- FIX: The Fixed a state can not transition in OnStateEnter.

Ver 1.6.1:
- FIX: Error is displayed if you press Grid button in the Mac environment.

Ver 1.6: 
- ADD: Resident state.
- ADD: Multilingual.
- ADD: Correspondence to be named to ArborFSM.
- FIX: Are not reflected in the snap interval when you change the grid size.
- FIX: Deal of the problems StateBehaviour is lost when you copy and paste a component of ArborFSM.
- FIX: Modified to send only to the state currently in effect the SendTrigger.
- FIX: StateBehaviour continues to move If you disable ArborFSM.

Ver 1.5: 
- ADD: Support for multiple selection of the state. 
- ADD: Support for shortcut key. 
- ADD: grid display support. 
- FIX: it placed in a state in which it is spread by default when adding Behaviour. 
- FIX: I react mouse over to the state is shifted while dragging StateLink.

ver 1.4: 
- ADD: Tween-based Behaviour added. 
  - Tween / Color 
  - Tween / Position 
  - Tween / Rotation 
  - Tween / Scale 
- ADD: The HideBehaviour to add attributes that do not appear in the Add Behaviour. 
- ADD: online help of the built-in display Behaviour from the Help button on the Behaviour.

ver 1.3: 
- ADD: Add built-in Behaviour. 
  - Audio / PlaySoundAtPoint 
  - GameObject / SendMessage 
  - Scene / LoadLevel 
  - Transition / Force 
- ADD: Copy and paste across the scene. 
- FIX: memory leak warning is displayed when you save the scene after which you copied the State. 
- FIX: arrow will remain when you scroll the screen to drag the connection of the StateLink.

ver 1.2: 
- ADD: Enabled check box of StateBehaviour. 
- FIX: Errors Occur When you release the maximization of Arbor Editor. 
- FIX: Warning of the new line of code can when you edit a C# script that generated.

ver 1.1: 
- ADD: script generation of Boo and JavaScript. 
- ADD: Copy and paste the State. 
- ADD: Copy and paste the StateBehaviour. 
- FIX: support when the script becomes Missing. 
- FIX: Fixed array of StateLink is not displayed.

ver 1.0.1: 
- FIX: Error in Unity4.5. 
- FIX: Arbor Editor is not repaint when running in the editor. 
- FIX: class name of the Inspector extension of ArborFSM.
