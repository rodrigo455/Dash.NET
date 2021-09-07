namespace Dash.NET.DCC

//open Dash.NET
//open System
//open Plotly.NET
//open Newtonsoft.Json

/////<summary>
/////Checklist is a component that encapsulates several checkboxes.
/////The values and labels of the checklist are specified in the &#96;options&#96;
/////property and the checked items are specified with the &#96;value&#96; property.
/////Each checkbox is rendered as an input with a surrounding label.
/////</summary>
//[<RequireQualifiedAccess>]
//module Checklist =
//    ///<summary>
//    ///value equal to: 'local', 'session', 'memory'
//    ///</summary>
//    type PersistenceTypeType =
//        | Local
//        | Session
//        | Memory
//        static member convert(this) =
//            box (
//                match this with
//                | Local -> "local"
//                | Session -> "session"
//                | Memory -> "memory"
//            )

//    ///<summary>
//    ///value equal to: 'value'
//    ///</summary>
//    type PersistedPropsTypeType =
//        | Value
//        static member convert(this) =
//            box (
//                match this with
//                | Value -> "value"
//            )

//    ///<summary>
//    ///list with values of type: value equal to: 'value'
//    ///</summary>
//    type PersistedPropsType =
//        | PersistedPropsType of list<PersistedPropsTypeType>
//        static member convert(this) =
//            box (
//                match this with
//                | PersistedPropsType (v) ->
//                    List.map (fun (i: PersistedPropsTypeType) -> box (i |> PersistedPropsTypeType.convert)) v
//            )

//    ///<summary>
//    ///boolean | string | number
//    ///</summary>
//    type PersistenceType =
//        | Bool of bool
//        | String of string
//        | IConvertible of IConvertible
//        static member convert(this) =
//            match this with
//            | Bool (v) -> box v
//            | String (v) -> box v
//            | IConvertible (v) -> box v

//    ///<summary>
//    ///record with the fields: 'is_loading: boolean (optional)', 'prop_name: string (optional)', 'component_name: string (optional)'
//    ///</summary>
//    type LoadingStateType =
//        { IsLoading: bool
//          PropName: string
//          ComponentName: string }
//        static member convert(this) =
//            box
//                {| is_loading = this.IsLoading
//                   prop_name = this.PropName
//                   component_name = this.ComponentName |}

//    ///<summary>
//    ///string | number
//    ///</summary>
//    type ValueTypeType =
//        | String of string
//        | IConvertible of IConvertible
//        static member convert(this) =
//            match this with
//            | String (v) -> box v
//            | IConvertible (v) -> box v

//    ///<summary>
//    ///list with values of type: string | number
//    ///</summary>
//    type ValueType =
//        | ValueType of list<ValueTypeType>
//        static member convert(this) =
//            box (
//                match this with
//                | ValueType (v) -> List.map (fun (i: ValueTypeType) -> box (i |> ValueTypeType.convert)) v
//            )

//    ///<summary>
//    ///string | number
//    ///&#10;
//    ///The value of the checkbox. This value
//    ///corresponds to the items specified in the
//    ///&#96;value&#96; property.
//    ///</summary>
//    type OptionsTypeTypeValueType =
//        | String of string
//        | IConvertible of IConvertible
//        static member convert(this) =
//            match this with
//            | String (v) -> box v
//            | IConvertible (v) -> box v

//    ///<summary>
//    ///string | number
//    ///&#10;
//    ///The checkbox's label
//    ///</summary>
//    type OptionsTypeTypeLabelType =
//        | String of string
//        | IConvertible of IConvertible
//        static member convert(this) =
//            match this with
//            | String (v) -> box v
//            | IConvertible (v) -> box v

//    ///<summary>
//    ///record with the fields: 'label: string | number (required)', 'value: string | number (required)', 'disabled: boolean (optional)'
//    ///</summary>
//    type OptionsTypeType =
//        { Label: OptionsTypeTypeLabelType
//          Value: OptionsTypeTypeValueType
//          Disabled: bool }
//        static member convert(this) =
//            box
//                {| label = (this.Label |> OptionsTypeTypeLabelType.convert)
//                   value = (this.Value |> OptionsTypeTypeValueType.convert)
//                   disabled = this.Disabled |}

//    ///<summary>
//    ///list with values of type: record with the fields: 'label: string | number (required)', 'value: string | number (required)', 'disabled: boolean (optional)'
//    ///</summary>
//    type OptionsType =
//        | OptionsType of list<OptionsTypeType>
//        static member convert(this) =
//            box (
//                match this with
//                | OptionsType (v) -> List.map (fun (i: OptionsTypeType) -> box (i |> OptionsTypeType.convert)) v
//            )

//    ///<summary>
//    ///• options (list with values of type: record with the fields: 'label: string | number (required)', 'value: string | number (required)', 'disabled: boolean (optional)'; default []) - An array of options
//    ///&#10;
//    ///• value (list with values of type: string | number; default []) - The currently selected value
//    ///&#10;
//    ///• className (string) - The class of the container (div)
//    ///&#10;
//    ///• style (record) - The style of the container (div)
//    ///&#10;
//    ///• inputStyle (record; default {}) - The style of the &lt;input&gt; checkbox element
//    ///&#10;
//    ///• inputClassName (string; default ) - The class of the &lt;input&gt; checkbox element
//    ///&#10;
//    ///• labelStyle (record; default {}) - The style of the &lt;label&gt; that wraps the checkbox input
//    /// and the option's label
//    ///&#10;
//    ///• labelClassName (string; default ) - The class of the &lt;label&gt; that wraps the checkbox input
//    /// and the option's label
//    ///&#10;
//    ///• loading_state (record with the fields: 'is_loading: boolean (optional)', 'prop_name: string (optional)', 'component_name: string (optional)') - Object that holds the loading state object coming from dash-renderer
//    ///&#10;
//    ///• persistence (boolean | string | number) - Used to allow user interactions in this component to be persisted when
//    ///the component - or the page - is refreshed. If &#96;persisted&#96; is truthy and
//    ///hasn't changed from its previous value, a &#96;value&#96; that the user has
//    ///changed while using the app will keep that change, as long as
//    ///the new &#96;value&#96; also matches what was given originally.
//    ///Used in conjunction with &#96;persistence_type&#96;.
//    ///&#10;
//    ///• persisted_props (list with values of type: value equal to: 'value'; default ['value']) - Properties whose user interactions will persist after refreshing the
//    ///component or the page. Since only &#96;value&#96; is allowed this prop can
//    ///normally be ignored.
//    ///&#10;
//    ///• persistence_type (value equal to: 'local', 'session', 'memory'; default local) - Where persisted user changes will be stored:
//    ///memory: only kept in memory, reset on page refresh.
//    ///local: window.localStorage, data is kept after the browser quit.
//    ///session: window.sessionStorage, data is cleared once the browser quit.
//    ///</summary>
//    type Prop =
//        | Options of OptionsType
//        | Value of ValueType
//        | ClassName of string
//        | Style of obj
//        | InputStyle of obj
//        | InputClassName of string
//        | LabelStyle of obj
//        | LabelClassName of string
//        | LoadingState of LoadingStateType
//        | Persistence of PersistenceType
//        | PersistedProps of PersistedPropsType
//        | PersistenceType of PersistenceTypeType
//        static member toDynamicMemberDef(prop: Prop) =
//            match prop with
//            | Options (p) -> "options", p |> OptionsType.convert
//            | Value (p) -> "value", p |> ValueType.convert
//            | ClassName (p) -> "className", box p
//            | Style (p) -> "style", box p
//            | InputStyle (p) -> "inputStyle", box p
//            | InputClassName (p) -> "inputClassName", box p
//            | LabelStyle (p) -> "labelStyle", box p
//            | LabelClassName (p) -> "labelClassName", box p
//            | LoadingState (p) -> "loading_state", p |> LoadingStateType.convert
//            | Persistence (p) -> "persistence", p |> PersistenceType.convert
//            | PersistedProps (p) -> "persisted_props", p |> PersistedPropsType.convert
//            | PersistenceType (p) -> "persistence_type", p |> PersistenceTypeType.convert

//    ///<summary>
//    ///A list of children or a property for this dash component
//    ///</summary>
//    type Attr =
//        | Prop of Prop
//        | Children of list<DashComponent>
//        ///<summary>
//        ///An array of options
//        ///</summary>
//        static member options(p: OptionsType) = Prop(Options p)
//        ///<summary>
//        ///The currently selected value
//        ///</summary>
//        static member value(p: ValueType) = Prop(Value p)
//        ///<summary>
//        ///The class of the container (div)
//        ///</summary>
//        static member className(p: string) = Prop(ClassName p)
//        ///<summary>
//        ///The style of the container (div)
//        ///</summary>
//        static member style(p: obj) = Prop(Style p)
//        ///<summary>
//        ///The style of the &lt;input&gt; checkbox element
//        ///</summary>
//        static member inputStyle(p: obj) = Prop(InputStyle p)
//        ///<summary>
//        ///The class of the &lt;input&gt; checkbox element
//        ///</summary>
//        static member inputClassName(p: string) = Prop(InputClassName p)
//        ///<summary>
//        ///The style of the &lt;label&gt; that wraps the checkbox input
//        /// and the option's label
//        ///</summary>
//        static member labelStyle(p: obj) = Prop(LabelStyle p)
//        ///<summary>
//        ///The class of the &lt;label&gt; that wraps the checkbox input
//        /// and the option's label
//        ///</summary>
//        static member labelClassName(p: string) = Prop(LabelClassName p)
//        ///<summary>
//        ///Object that holds the loading state object coming from dash-renderer
//        ///</summary>
//        static member loadingState(p: LoadingStateType) = Prop(LoadingState p)
//        ///<summary>
//        ///Used to allow user interactions in this component to be persisted when
//        ///the component - or the page - is refreshed. If &#96;persisted&#96; is truthy and
//        ///hasn't changed from its previous value, a &#96;value&#96; that the user has
//        ///changed while using the app will keep that change, as long as
//        ///the new &#96;value&#96; also matches what was given originally.
//        ///Used in conjunction with &#96;persistence_type&#96;.
//        ///</summary>
//        static member persistence(p: bool) =
//            Prop(Persistence(PersistenceType.Bool p))

//        ///<summary>
//        ///Used to allow user interactions in this component to be persisted when
//        ///the component - or the page - is refreshed. If &#96;persisted&#96; is truthy and
//        ///hasn't changed from its previous value, a &#96;value&#96; that the user has
//        ///changed while using the app will keep that change, as long as
//        ///the new &#96;value&#96; also matches what was given originally.
//        ///Used in conjunction with &#96;persistence_type&#96;.
//        ///</summary>
//        static member persistence(p: string) =
//            Prop(Persistence(PersistenceType.String p))

//        ///<summary>
//        ///Used to allow user interactions in this component to be persisted when
//        ///the component - or the page - is refreshed. If &#96;persisted&#96; is truthy and
//        ///hasn't changed from its previous value, a &#96;value&#96; that the user has
//        ///changed while using the app will keep that change, as long as
//        ///the new &#96;value&#96; also matches what was given originally.
//        ///Used in conjunction with &#96;persistence_type&#96;.
//        ///</summary>
//        static member persistence(p: IConvertible) =
//            Prop(Persistence(PersistenceType.IConvertible p))

//        ///<summary>
//        ///Properties whose user interactions will persist after refreshing the
//        ///component or the page. Since only &#96;value&#96; is allowed this prop can
//        ///normally be ignored.
//        ///</summary>
//        static member persistedProps(p: PersistedPropsType) = Prop(PersistedProps p)
//        ///<summary>
//        ///Where persisted user changes will be stored:
//        ///memory: only kept in memory, reset on page refresh.
//        ///local: window.localStorage, data is kept after the browser quit.
//        ///session: window.sessionStorage, data is cleared once the browser quit.
//        ///</summary>
//        static member persistenceType(p: PersistenceTypeType) = Prop(PersistenceType p)
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: int) = Children([ Html.text value ])
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: string) = Children([ Html.text value ])
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: float) = Children([ Html.text value ])
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: System.Guid) = Children([ Html.text value ])
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: DashComponent) = Children([ value ])
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: list<DashComponent>) = Children(value)
//        ///<summary>
//        ///The child or children of this dash component
//        ///</summary>
//        static member children(value: seq<DashComponent>) = Children(List.ofSeq value)

//    ///<summary>
//    ///Checklist is a component that encapsulates several checkboxes.
//    ///The values and labels of the checklist are specified in the &#96;options&#96;
//    ///property and the checked items are specified with the &#96;value&#96; property.
//    ///Each checkbox is rendered as an input with a surrounding label.
//    ///</summary>
//    type Checklist() =
//        inherit DashComponent()
//        static member applyMembers
//            (
//                id: string,
//                children: seq<DashComponent>,
//                ?options: OptionsType,
//                ?value: ValueType,
//                ?className: string,
//                ?style: obj,
//                ?inputStyle: obj,
//                ?inputClassName: string,
//                ?labelStyle: obj,
//                ?labelClassName: string,
//                ?loadingState: LoadingStateType,
//                ?persistence: PersistenceType,
//                ?persistedProps: PersistedPropsType,
//                ?persistenceType: PersistenceTypeType
//            ) =
//            (fun (t: Checklist) ->
//                let props = DashComponentProps()
//                DynObj.setValue props "id" id
//                DynObj.setValue props "children" children
//                DynObj.setValueOpt props "options" (options |> Option.map OptionsType.convert)
//                DynObj.setValueOpt props "value" (value |> Option.map ValueType.convert)
//                DynObj.setValueOpt props "className" (className |> Option.map box)
//                DynObj.setValueOpt props "style" (style |> Option.map box)
//                DynObj.setValueOpt props "inputStyle" (inputStyle |> Option.map box)
//                DynObj.setValueOpt props "inputClassName" (inputClassName |> Option.map box)
//                DynObj.setValueOpt props "labelStyle" (labelStyle |> Option.map box)
//                DynObj.setValueOpt props "labelClassName" (labelClassName |> Option.map box)
//                DynObj.setValueOpt props "loadingState" (loadingState |> Option.map LoadingStateType.convert)
//                DynObj.setValueOpt props "persistence" (persistence |> Option.map PersistenceType.convert)
//                DynObj.setValueOpt props "persistedProps" (persistedProps |> Option.map PersistedPropsType.convert)
//                DynObj.setValueOpt props "persistenceType" (persistenceType |> Option.map PersistenceTypeType.convert)
//                DynObj.setValue t "namespace" "dash_core_components"
//                DynObj.setValue t "props" props
//                DynObj.setValue t "type" "Checklist"
//                t)

//        static member init
//            (
//                id: string,
//                children: seq<DashComponent>,
//                ?options: OptionsType,
//                ?value: ValueType,
//                ?className: string,
//                ?style: obj,
//                ?inputStyle: obj,
//                ?inputClassName: string,
//                ?labelStyle: obj,
//                ?labelClassName: string,
//                ?loadingState: LoadingStateType,
//                ?persistence: PersistenceType,
//                ?persistedProps: PersistedPropsType,
//                ?persistenceType: PersistenceTypeType
//            ) =
//            Checklist.applyMembers
//                (id,
//                 children,
//                 ?options = options,
//                 ?value = value,
//                 ?className = className,
//                 ?style = style,
//                 ?inputStyle = inputStyle,
//                 ?inputClassName = inputClassName,
//                 ?labelStyle = labelStyle,
//                 ?labelClassName = labelClassName,
//                 ?loadingState = loadingState,
//                 ?persistence = persistence,
//                 ?persistedProps = persistedProps,
//                 ?persistenceType = persistenceType)
//                (Checklist())

//    ///<summary>
//    ///Checklist is a component that encapsulates several checkboxes.
//    ///The values and labels of the checklist are specified in the &#96;options&#96;
//    ///property and the checked items are specified with the &#96;value&#96; property.
//    ///Each checkbox is rendered as an input with a surrounding label.
//    ///&#10;
//    ///Properties:
//    ///&#10;
//    ///• id (string) - The ID of this component, used to identify dash components
//    ///in callbacks. The ID needs to be unique across all of the
//    ///components in an app.
//    ///&#10;
//    ///• options (list with values of type: record with the fields: 'label: string | number (required)', 'value: string | number (required)', 'disabled: boolean (optional)'; default []) - An array of options
//    ///&#10;
//    ///• value (list with values of type: string | number; default []) - The currently selected value
//    ///&#10;
//    ///• className (string) - The class of the container (div)
//    ///&#10;
//    ///• style (record) - The style of the container (div)
//    ///&#10;
//    ///• inputStyle (record; default {}) - The style of the &lt;input&gt; checkbox element
//    ///&#10;
//    ///• inputClassName (string; default ) - The class of the &lt;input&gt; checkbox element
//    ///&#10;
//    ///• labelStyle (record; default {}) - The style of the &lt;label&gt; that wraps the checkbox input
//    /// and the option's label
//    ///&#10;
//    ///• labelClassName (string; default ) - The class of the &lt;label&gt; that wraps the checkbox input
//    /// and the option's label
//    ///&#10;
//    ///• loading_state (record with the fields: 'is_loading: boolean (optional)', 'prop_name: string (optional)', 'component_name: string (optional)') - Object that holds the loading state object coming from dash-renderer
//    ///&#10;
//    ///• persistence (boolean | string | number) - Used to allow user interactions in this component to be persisted when
//    ///the component - or the page - is refreshed. If &#96;persisted&#96; is truthy and
//    ///hasn't changed from its previous value, a &#96;value&#96; that the user has
//    ///changed while using the app will keep that change, as long as
//    ///the new &#96;value&#96; also matches what was given originally.
//    ///Used in conjunction with &#96;persistence_type&#96;.
//    ///&#10;
//    ///• persisted_props (list with values of type: value equal to: 'value'; default ['value']) - Properties whose user interactions will persist after refreshing the
//    ///component or the page. Since only &#96;value&#96; is allowed this prop can
//    ///normally be ignored.
//    ///&#10;
//    ///• persistence_type (value equal to: 'local', 'session', 'memory'; default local) - Where persisted user changes will be stored:
//    ///memory: only kept in memory, reset on page refresh.
//    ///local: window.localStorage, data is kept after the browser quit.
//    ///session: window.sessionStorage, data is cleared once the browser quit.
//    ///</summary>
//    let checklist (id: string) (attrs: list<Attr>) =
//        let props, children =
//            List.fold
//                (fun (props, children) (a: Attr) ->
//                    match a with
//                    | Prop (prop) -> prop :: props, children
//                    | Children (child) -> props, child @ children)
//                ([], [])
//                attrs

//        let t = Checklist.init (id, children)

//        let componentProps =
//            match t.TryGetTypedValue<DashComponentProps> "props" with
//            | Some (p) -> p
//            | None -> DashComponentProps()

//        Seq.iter
//            (fun (prop: Prop) ->
//                let fieldName, boxedProp = Prop.toDynamicMemberDef prop
//                DynObj.setValue componentProps fieldName boxedProp)
//            props

//        DynObj.setValue t "props" componentProps
//        t :> DashComponent
