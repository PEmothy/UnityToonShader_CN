//#define USE_SIMPLE_UI


using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEditor.Rendering.Toon
{
    internal partial class UTS3GUI : UnityEditor.ShaderGUI
    {


        internal const float kVersionX = 0.0f;
        internal const float kVersionY = 9.0f;
        internal const float kVersionZ = 5.0f;

        internal static string versionString => "0.9.5-preview";

        // Render Pipelines UTS supports are the followings 
        internal enum RenderPipeline
        {

            Legacy,
            Universal,
            HDRP,
            Unknown,
        }

        internal static RenderPipeline currentRenderPipeline
        {
            get
            {
                const string kHdrpShaderPrefix = "HDRP/";
                const string kUrpShaderPrefix = "Universal Render Pipeline/";
                var currentRenderPipeline = GraphicsSettings.currentRenderPipeline;
                if (currentRenderPipeline == null)
                {
                    return RenderPipeline.Legacy; 
                }
                if (currentRenderPipeline.defaultMaterial.shader.name.StartsWith(kHdrpShaderPrefix))
                {
                    return RenderPipeline.HDRP;
                }
                if (currentRenderPipeline.defaultMaterial.shader.name.StartsWith(kUrpShaderPrefix))
                {
                    return RenderPipeline.Universal;
                }
                return RenderPipeline.Unknown;
            }
        }
        internal static string srpDefaultLightModeName 
        {
             get
             {
                const string legacyDefaultLightModeName = "Always";
                const string srpDefaultLightModeName = "SRPDefaultUnlit";

                if (currentRenderPipeline == RenderPipeline.Legacy)
                {
                    return legacyDefaultLightModeName; // default.
                }

                return srpDefaultLightModeName;
             }
        }



        internal  void RenderingPerChennelsSetting(Material material) 
        {
            if (currentRenderPipeline == RenderPipeline.HDRP)
            {

                RenderingPerChennelsSettingHDRP(material);
            }
        }
        internal  void ApplyTessellation(Material materal) 
        {
            if (currentRenderPipeline == RenderPipeline.HDRP)
            {
                ApplyTessellationHDRP(materal);
            }
        }
        internal  void ApplyRenderingPerChennelsSetting(Material material) 
        {

        }
        internal  void FindTessellationProperties(MaterialProperty[] props) 
        {
            if (currentRenderPipeline == RenderPipeline.HDRP)
            {

                FindTessellationPropertiesHDRP(props);
            }
        }

        internal const string ShaderDefineSHADINGGRADEMAP = "_SHADINGGRADEMAP";
        internal const string ShaderDefineANGELRING_ON = "_IS_ANGELRING_ON";
        internal const string ShaderDefineANGELRING_OFF = "_IS_ANGELRING_OFF";
        internal const string ShaderDefineUTS_USE_RAYTRACING_SHADOW = "UTS_USE_RAYTRACING_SHADOW";
        internal const string ShaderPropAngelRing = "_AngelRing";
        internal const string ShaderPropRTHS = "_RTHS";
        internal const string ShaderPropMatCap = "_MatCap";
        internal const string ShaderPropMainTex = "_MainTex";
        internal const string ShaderPropClippingMode = "_ClippingMode";
        internal const string ShaderPropClippingMask = "_ClippingMask";
        internal const string ShaderProp_Set_1st_ShadePosition = "_Set_1st_ShadePosition";
        internal const string ShaderProp_Set_2nd_ShadePosition = "_Set_2nd_ShadePosition";
        internal const string ShaderProp_ShadingGradeMap = "_ShadingGradeMap";
        internal const string ShaderProp_Set_RimLightMask = "_Set_RimLightMask";
        internal const string ShaderProp_HighColor_Tex = "_HighColor_Tex";
        internal const string ShaderProp_Set_HighColorMask = "_Set_HighColorMask";
        internal const string ShaderProp_MatCap_Sampler = "_MatCap_Sampler";
        internal const string ShaderProp_Set_MatcapMask = "_Set_MatcapMask";
        internal const string ShaderProp_OutlineTex = "_OutlineTex";
        internal const string ShaderProp_Outline_Sampler = "_Outline_Sampler";

        internal const string ShaderPropSimpleUI = "_simpleUI";
        internal const string ShaderPropUtsTechniqe = "_utsTechnique";
        internal const string ShaderPropAutoRenderQueue = "_AutoRenderQueue";
        internal const string ShaderPropStencilMode = "_StencilMode";
        internal const string ShaderPropStencilNo = "_StencilNo";
        internal const string ShaderPropTransparentEnabled = "_TransparentEnabled";
        internal const string ShaderPropStencilComp = "_StencilComp";
        internal const string ShaderPropStencilOpPass = "_StencilOpPass";
        internal const string ShaderPropStencilOpFail = "_StencilOpFail";
        internal const string ShaderPropStencilWriteMask = "_StencilWriteMask";
        internal const string ShaderPropStencilReadMask = "_StencilReadMask";
        internal const string ShaderPropUtsVersionX = "_utsVersionX";
        internal const string ShaderPropUtsVersionY = "_utsVersionY";
        internal const string ShaderPropUtsVersionZ = "_utsVersionZ";
        internal const string ShaderPropIsUnityToonShader = "_isUnityToonshader";
        internal const string ShaderPropOutline = "_OUTLINE";
        internal const string ShaderPropNormalMapToHighColor = "_Is_NormalMapToHighColor";
        internal const string ShaderPropIsNormalMapToRimLight = "_Is_NormalMapToRimLight";
        internal const string ShaderPropSetSystemShadowsToBase = "_Set_SystemShadowsToBase";
        internal const string ShaderPropIsFilterHiCutPointLightColor = "_Is_Filter_HiCutPointLightColor";
        internal const string ShaderPropInverseClipping = "_Inverse_Clipping";
        internal const string ShaderPropIsBaseMapAlphaAsClippingMask = "_IsBaseMapAlphaAsClippingMask";
        internal const string ShaderPropIsLightColor_Base = "_Is_LightColor_Base";
        internal const string ShaderPropCameraRolling_Stabilizer = "_CameraRolling_Stabilizer";
        internal const string ShaderPropIs_Ortho = "_Is_Ortho";
        internal const string ShaderPropGI_Intensity = "_GI_Intensity";
        internal const string ShaderPropUnlit_Intensity = "_Unlit_Intensity";


        internal const string ShaderPropIs_Filter_LightColor = "_Is_Filter_LightColor";
        internal const string ShaderPropIs_LightColor_1st_Shade = "_Is_LightColor_1st_Shade";
        internal const string ShaderPropIs_LightColor_2nd_Shade = "_Is_LightColor_2nd_Shade";
        internal const string ShaderPropIs_LightColor_HighColor = "_Is_LightColor_HighColor";
        internal const string ShaderPropIs_LightColor_RimLight = "_Is_LightColor_RimLight";
        internal const string ShaderPropIs_LightColor_Ap_RimLight = "_Is_LightColor_Ap_RimLight";
        internal const string ShaderPropIs_LightColor_MatCap = "_Is_LightColor_MatCap";
        internal const string ShaderPropIs_LightColor_AR = "_Is_LightColor_AR";
        internal const string ShaderPropIs_LightColor_Outline = "_Is_LightColor_Outline";
        internal const string ShaderPropInvert_MatcapMask = "_Inverse_MatcapMask";
        internal const string ShaderPropUse_BaseAs1st = "_Use_BaseAs1st";
        internal const string ShaderPropUse_1stAs2nd = "_Use_1stAs2nd";
        internal const string ShaderPropIs_NormalMapToBase = "_Is_NormalMapToBase";
        internal const string ShaderPropIs_ColorShift = "_Is_ColorShift";
        internal const string ShaderPropRimLight = "_RimLight";
        internal const string ShaderPropRimLight_FeatherOff = "_RimLight_FeatherOff";
        internal const string ShaderPropAp_RimLight_FeatherOff = "_Ap_RimLight_FeatherOff";
        internal const string ShaderPropIs_BlendAddToMatCap = "_Is_BlendAddToMatCap";
        internal const string ShaderPropARSampler_AlphaOn = "_ARSampler_AlphaOn";
        internal const string ShaderPropIs_UseTweakHighColorOnShadow = "_Is_UseTweakHighColorOnShadow";

        internal const string ShaderPropIs_SpecularToHighColor = "_Is_SpecularToHighColor";
        internal const string ShaderPropIs_BlendAddToHiColor = "_Is_BlendAddToHiColor";

        internal const string ShaderPropAdd_Antipodean_RimLight = "_Add_Antipodean_RimLight";
        internal const string ShaderPropLightDirection_MaskOn = "_LightDirection_MaskOn";

        internal const string ShaderProp1st_ShadeColor_Step = "_1st_ShadeColor_Step";
        internal const string ShaderPropBaseColor_Step = "_BaseColor_Step";
        internal const string ShaderProp1st_ShadeColor_Feather = "_1st_ShadeColor_Feather";
        internal const string ShaderPropBaseShade_Feather = "_BaseShade_Feather";
        internal const string ShaderProp2nd_ShadeColor_Step = "_2nd_ShadeColor_Step";
        internal const string ShaderPropShadeColor_Step = "_ShadeColor_Step";
        internal const string ShaderProp2nd_ShadeColor_Feather = "_2nd_ShadeColor_Feather";
        internal const string ShaderProp1st2nd_Shades_Feather = "_1st2nd_Shades_Feather";
        internal const string ShaderPropIs_NormalMapForMatCap = "_Is_NormalMapForMatCap";
        internal const string ShaderPropIs_UseTweakMatCapOnShadow = "_Is_UseTweakMatCapOnShadow";
        internal const string ShaderPropIs_ViewCoord_Scroll = "_Is_ViewCoord_Scroll";
        internal const string ShaderPropIs_PingPong_Base = "_Is_PingPong_Base";

        internal const string ShaderPropIs_ViewShift = "_Is_ViewShift";
        internal const string ShaderPropIs_BlendBaseColor = "_Is_BlendBaseColor";
        internal const string ShaderPropIs_OutlineTex = "_Is_OutlineTex";
        internal const string ShaderPropIs_BakedNormal = "_Is_BakedNormal";
        internal const string ShaderPropIs_BLD = "_Is_BLD";
        internal const string ShaderPropInverse_Z_Axis_BLD = "_Inverse_Z_Axis_BLD";


        internal const string ShaderDefineIS_OUTLINE_CLIPPING_NO = "_IS_OUTLINE_CLIPPING_NO";
        internal const string ShaderDefineIS_OUTLINE_CLIPPING_YES = "_IS_OUTLINE_CLIPPING_YES";

        internal const string ShaderDefineIS_CLIPPING_OFF = "_IS_CLIPPING_OFF";
        internal const string ShaderDefineIS_CLIPPING_MODE = "_IS_CLIPPING_MODE";
        internal const string ShaderDefineIS_CLIPPING_TRANSMODE = "_IS_CLIPPING_TRANSMODE";

        internal const string ShaderDefineIS_TRANSCLIPPING_OFF = "_IS_TRANSCLIPPING_OFF";
        internal const string ShaderDefineIS_TRANSCLIPPING_ON = "_IS_TRANSCLIPPING_ON";

        internal const string ShaderDefineIS_CLIPPING_MATTE = "_IS_CLIPPING_MATTE";


        protected readonly string[] UtsModeNames = { "标准", "带有额外的控制贴图" };
        protected readonly string[] EmissiveScrollMode = { "UV坐标滚动", "视图坐标滚动" };
        protected readonly string[] ClippingModeNames = { "关闭", "打开", "裁剪透明度" };
        protected readonly string[] StencilModeNames = { "关闭", "如果不等于则绘制", "用替换Stencil缓冲" };

        public enum UTS_Mode : uint
        {
            ThreeColorToon, ShadingGradeMap
        }

        public enum UTS_ClippingMode
        {
            Off, On, TransClippingMode
        }

        public enum UTS_TransClippingMode
        {
            Off, On,
        }
        public enum UTS_TransparentMode : uint
        {
            Off, On,
        }
        public enum UTS_StencilMode
        {
            Off, StencilOut, StencilMask
        }
        public enum UTS_SpeculerMode
        {
            Hard, Soft
        }
        public enum UTS_SpeculerColorBlendMode
        {
            Multiply, Add
        }
        public enum UTS_MatcapColorBlendMode
        {
            Multiply, Add
        }

        public enum StencilOperation
        {
            //https://docs.unity3d.com/Manual/SL-Stencil.html
            Keep, //    Keep the current contents of the buffer.
            Zero, //    Write 0 into the buffer.
            Replace, // Write the reference value into the buffer.
            IncrSat, // Increment the current value in the buffer. If the value is 255 already, it stays at 255.
            DecrSat, // Decrement the current value in the buffer. If the value is 0 already, it stays at 0.
            Invert, //  Negate all the bits.
            IncrWrap, //    Increment the current value in the buffer. If the value is 255 already, it becomes 0.
            DecrWrap, //    Decrement the current value in the buffer. If the value is 0 already, it becomes 255.
        }

        public enum StencilCompFunction
        {

            Disabled,//    Depth or stencil test is disabled.
            Never,   //   Never pass depth or stencil test.
            Less,   //   Pass depth or stencil test when new value is less than old one.
            Equal,  //  Pass depth or stencil test when values are equal.
            LessEqual, // Pass depth or stencil test when new value is less or equal than old one.
            Greater, // Pass depth or stencil test when new value is greater than old one.
            NotEqual, //    Pass depth or stencil test when values are different.
            GreaterEqual, // Pass depth or stencil test when new value is greater or equal than old one.
            Always,//  Always pass depth or stencil test.
        }



        public enum OutlineMode
        {
            NormalDirection, PositionScaling
        }

        public enum CullingMode
        {
            Off, Frontface, Backface
        }

        public enum EmissionMode
        {
            SimpleEmissive, EmissiveAnimation
        }

        public enum CameraProjectionType
        {
            Perspective,
            Orthographic
        }

        [Flags]
#if UNITY_2021_1_OR_NEWER
        [UTS3InspectorHelpURL("instruction")]
#endif // UNITY_2021_1_OR_NEWER
        protected enum Expandable
        {
            Shader = 1 << 0,
            Basic = 1 << 1,
            ShadingStepAndFeather = 1 << 2,
            NormalMap = 1 << 3,
            Highlight = 1 << 4,
            Rimlight = 1 << 5,
            MatCap = 1 << 6,
            AngelRing = 1 << 7,
            Emission = 1 << 8,
            Outline = 1 << 9,
            TessellationLegacy = 1 << 10,
            TessellationHDRP = 1 << 11,
            SceneLight = 1 << 12,
            EnvironmentalLightEffectiveness = 1 << 13,
            MetaverseSettings = 1 << 14,
        }

        // variables which must be gotten from shader at the beggning of GUI
        internal int m_autoRenderQueue = 1;
        internal int m_renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
        // variables which just to be held.
        internal OutlineMode m_outlineMode;
        internal CullingMode m_cullingMode;
        internal EmissionMode m_emissionMode;
        internal bool m_FirstTimeApply = true;
        UTS_Mode m_WorkflowMode;



        readonly UTS3MaterialHeaderScopeList m_MaterialScopeList = new UTS3MaterialHeaderScopeList(uint.MaxValue & ~(uint)Expandable.Basic);


        //Button sizes
        static internal GUILayoutOption[] longButtonStyle = new GUILayoutOption[] { GUILayout.Width(180) };
        static internal GUILayoutOption[] shortButtonStyle = new GUILayoutOption[] { GUILayout.Width(130) };
        static internal GUILayoutOption[] middleButtonStyle = new GUILayoutOption[] { GUILayout.Width(130) };
        static internal GUILayoutOption[] toggleStyle = new GUILayoutOption[] { GUILayout.Width(130) };

        //
        protected UTS_TransparentMode transparencyEnabled;
        protected int stencilNumberSetting;

        protected static bool _SimpleUI = false;

        //Initial values of Foldout.


        protected  bool _NormalMap_Foldout = false;
        protected  bool _ShadowControlMaps_Foldout = false;
        protected  bool _AdditionalLookdevs_Foldout = false;
        protected  bool _AdvancedOutline_Foldout = false;



        // -----------------------------------------------------
        //Specify only those that use the m_MaterialEditor method as their UI.
        // UTS3 materal properties -------------------------
        protected MaterialProperty utsTechnique = null;
        protected MaterialProperty specularMode = null;
        protected MaterialProperty specularBlendMode = null;
        protected MaterialProperty matcapCameraMode = null;
        protected MaterialProperty matcapBlendMode = null;
        protected MaterialProperty matcapOrtho = null;
        protected MaterialProperty transparentMode = null;
        protected MaterialProperty clippingMode = null;
        protected MaterialProperty clippingMask = null;

        protected MaterialProperty stencilValue = null;

        protected MaterialProperty stencilMode = null;
        protected MaterialProperty mainTex = null;
        protected MaterialProperty baseColor = null;
        protected MaterialProperty firstShadeMap = null;
        protected MaterialProperty firstShadeColor = null;
        protected MaterialProperty secondShadeMap = null;
        protected MaterialProperty secondShadeColor = null;
        protected MaterialProperty normalMap = null;
        protected MaterialProperty bumpScale = null;
        protected MaterialProperty set_1st_ShadePosition = null;
        protected MaterialProperty set_2nd_ShadePosition = null;
        protected MaterialProperty shadingGradeMap = null;



        protected MaterialProperty highColor_Tex = null;
        protected MaterialProperty highColor = null;

        protected MaterialProperty set_HighColorMask = null;
        protected MaterialProperty tweak_HighColorMaskLevel = null;

        protected MaterialProperty rimLight_Power = null;
        protected MaterialProperty ap_RimLight_Power = null;
        protected MaterialProperty set_RimLightMask = null;

        protected MaterialProperty matCap_Sampler = null;
        protected MaterialProperty matCapColor = null;
        protected MaterialProperty normalMapForMatCap = null;
        protected MaterialProperty bumpScaleMatcap = null;
        protected MaterialProperty set_MatcapMask = null;

        protected MaterialProperty angelRing_Sampler = null;
        protected MaterialProperty angelRing_Color = null;

        protected MaterialProperty emissive_Tex = null;
        protected MaterialProperty emissive_Color = null;
        protected MaterialProperty rotate_EmissiveUV = null;

        protected MaterialProperty outline_Sampler = null;
        protected MaterialProperty offset_Z = null;
        protected MaterialProperty outlineTex = null;
        protected MaterialProperty bakedNormal = null;

        //------------------------------------------------------
        protected MaterialEditor m_MaterialEditor;

 



        const int HDRPGeometryMin = 2650; // UnityEngine.Rendering.RenderQueue.Geometry;
        internal static void UpdateVersionInMaterial(Material material)
        {
            MaterialSetInt(material,ShaderPropIsUnityToonShader, 1);
            material.SetFloat(ShaderPropUtsVersionX,  kVersionX);
            material.SetFloat(ShaderPropUtsVersionY,  kVersionY);
            material.SetFloat(ShaderPropUtsVersionZ,  kVersionZ);

        }








        private bool isShadingGrademap
        {
            get
            {

                Material material = m_MaterialEditor.target as Material;
                return MaterialGetInt(material,ShaderPropUtsTechniqe) == (int)UTS_Mode.ShadingGradeMap;

            }
        }



        void FindProperties(MaterialProperty[] props)
        {
            // false is added if theare are possiblities the properties are not aveialable
            utsTechnique = FindProperty(ShaderPropUtsTechniqe, props);
            specularMode = FindProperty(ShaderPropIs_SpecularToHighColor, props);
            specularBlendMode = FindProperty(ShaderPropIs_BlendAddToHiColor, props);
            matcapBlendMode = FindProperty(ShaderPropIs_BlendAddToMatCap, props);
            matcapCameraMode = FindProperty(ShaderPropIs_Ortho, props);
            transparentMode = FindProperty(ShaderPropTransparentEnabled, props);
            clippingMask = FindProperty(ShaderPropClippingMask, props);
            clippingMode = FindProperty(ShaderPropClippingMode, props);

            stencilValue = FindProperty(ShaderPropStencilNo, props);

            stencilMode = FindProperty(ShaderPropStencilMode, props);
            mainTex = FindProperty(ShaderPropMainTex, props);
            baseColor = FindProperty("_BaseColor", props);
            firstShadeMap = FindProperty("_1st_ShadeMap", props);
            firstShadeColor = FindProperty("_1st_ShadeColor", props);
            secondShadeMap = FindProperty("_2nd_ShadeMap", props);
            secondShadeColor = FindProperty("_2nd_ShadeColor", props);
            normalMap = FindProperty("_NormalMap", props);
            bumpScale = FindProperty("_BumpScale", props);
            set_1st_ShadePosition = FindProperty(ShaderProp_Set_1st_ShadePosition, props, false);
            set_2nd_ShadePosition = FindProperty(ShaderProp_Set_2nd_ShadePosition, props, false);
            shadingGradeMap = FindProperty(ShaderProp_ShadingGradeMap, props, false);


            highColor_Tex = FindProperty(ShaderProp_HighColor_Tex, props);
            highColor = FindProperty("_HighColor", props);

            set_HighColorMask = FindProperty(ShaderProp_Set_HighColorMask, props);
            tweak_HighColorMaskLevel = FindProperty("_Tweak_HighColorMaskLevel", props);


            set_RimLightMask = FindProperty(ShaderProp_Set_RimLightMask, props);

            matCap_Sampler = FindProperty(ShaderProp_MatCap_Sampler, props);
            matCapColor = FindProperty("_MatCapColor", props);

            normalMapForMatCap = FindProperty("_NormalMapForMatCap", props);
            bumpScaleMatcap = FindProperty("_BumpScaleMatcap", props);


            set_MatcapMask = FindProperty(ShaderProp_Set_MatcapMask, props);

            angelRing_Sampler = FindProperty("_AngelRing_Sampler", props, false);
            angelRing_Color = FindProperty("_AngelRing_Color", props, false);

            emissive_Tex = FindProperty("_Emissive_Tex", props);
            emissive_Color = FindProperty("_Emissive_Color", props);


            outline_Sampler = FindProperty(ShaderProp_Outline_Sampler, props, false);
            outlineTex = FindProperty(ShaderProp_OutlineTex, props, false);
            bakedNormal = FindProperty("_BakedNormal", props, false);



            FindTessellationProperties(props);
        }
        // --------------------------------

        // --------------------------------
        static void Line()
        {
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        }

        protected static bool Foldout(bool display, GUIContent title)
        {

            return EditorGUILayout.Foldout(display, title, true );
        }

        static bool FoldoutSubMenu(bool display, GUIContent title)
        {
            return EditorGUILayout.Foldout(display, title, true);
        }


        class RangeProperty
        {
            internal GUIContent m_GuiContent;
            internal readonly string m_propertyName;
            internal float m_Min;
            internal float m_Max;
            internal float m_DefaultValue;

            internal RangeProperty(string label, string tooltip, string propName, float defaultValue, float min, float max )
            {
                m_GuiContent = new GUIContent(label,tooltip + " The range is from " +  min + " to " + max + ". " + "The default value is " + defaultValue + ".");
                m_propertyName = propName;
                m_Min = min;
                m_Max = max;
                m_DefaultValue = defaultValue;
            }
        };

        class FloatProperty
        {
            internal GUIContent m_GuiContent;
            internal readonly string m_propertyName;
            internal float m_defaultValue;
            internal FloatProperty(string label, string tooltip, string propName, float defaultValue)
            {
                m_GuiContent = new GUIContent(label, tooltip + " The default value is " + defaultValue + ".");
                m_propertyName = propName;
                m_defaultValue = defaultValue;
            }
        }

        class ColorProperty
        {
            internal GUIContent m_GuiContent;
            internal readonly string m_propertyName;
            internal bool m_isHDR;

            internal ColorProperty(string label, string tooltip, string propName, bool isHDR)
            {
                m_GuiContent = new GUIContent(label, tooltip );
                m_propertyName = propName;
                m_isHDR = isHDR;
            }
        }



        // --------------------------------
        //Specify only those that use the m_MaterialEditor method as their UI. For specifying textures and colors on a single line.
        private static class Styles
        {
            public static readonly GUIContent shaderFoldout = EditorGUIUtility.TrTextContent("着色器设置", "着色器设置提供了一些基本设置，不仅限于卡通渲染，而是为一般的计算机图形学所需。");
            public static readonly GUIContent basicColorFoldout = EditorGUIUtility.TrTextContent("三色和控制图设置", "三色图和控制图设置为Unity Toon Shader的卡通渲染提供了非常基本的设置。");
            public static readonly GUIContent shadingStepAndFeatherFoldout = EditorGUIUtility.TrTextContent("阴影步骤和羽化设置", "基本的三色阴影步骤和羽化设置。");
            public static readonly GUIContent normalMapFoldout = EditorGUIUtility.TrTextContent("法线贴图设置", "法线贴图设置。法线贴图本身以及其对某些区域的影响。");
            public static readonly GUIContent highlightFoldout = EditorGUIUtility.TrTextContent("高光设置", "高光设置。如功率、显示或隐藏、光形状等。");
            public static readonly GUIContent rimLightFoldout = EditorGUIUtility.TrTextContent("边缘光设置", "边缘光设置。如颜色、方向、反向边缘光等。");
            public static readonly GUIContent matCapFoldout = EditorGUIUtility.TrTextContent("材质捕捉（MatCap）设置", "MatCap设置。用于金属或不寻常效果的球面贴图。");
            public static readonly GUIContent angelRingFoldout = EditorGUIUtility.TrTextContent("天使光环投影设置", "天使光环投影设置。一种专门用于头发的高光效果。");
            public static readonly GUIContent emissionFoldout = EditorGUIUtility.TrTextContent("发光设置", "发光设置。纹理、动画等。");
            public static readonly GUIContent outlineFoldout = EditorGUIUtility.TrTextContent("轮廓设置", "轮廓设置。如宽度、颜色等。");
            public static readonly GUIContent tessellationFoldout = EditorGUIUtility.TrTextContent("镶嵌设置", "DX11、DX12和Mac Metal的镶嵌设置。");
            public static readonly GUIContent maskRenderingFoldout = EditorGUIUtility.TrTextContent("遮罩渲染设置", "由可视合成器控制的遮罩渲染设置。");
            public static readonly GUIContent lightEffectivenessFoldout = EditorGUIUtility.TrTextContent("场景光照效果设置", "对每个参数的场景光照效果。");

            public static readonly GUIContent metaverseSettingsFoldout = EditorGUIUtility.TrTextContent("Metaverse设置（实验性）", "当场景中没有方向光时的默认方向光。");
            public static readonly GUIContent shadowControlMapFoldout = EditorGUIUtility.TrTextContent("阴影控制图设置", "阴影控制图设置。如位置和高光滤波。");
            public static readonly GUIContent pointLightFoldout = EditorGUIUtility.TrTextContent("点光源设置", "点光源设置。如滤波和步进偏移。");

            public static readonly GUIContent baseColorText = new GUIContent("基础贴图", "基础颜色：纹理（sRGB）×颜色（RGB） 默认：白色");
            public static readonly GUIContent firstShadeColorText = new GUIContent("第一阴影贴图", "用于阴影较亮部分的贴图。");
            public static readonly GUIContent secondShadeColorText = new GUIContent("第二阴影贴图", "用于阴影较暗部分的贴图。");
            public static readonly GUIContent normalMapText = new GUIContent("法线贴图", "规定材质凹凸程度的纹理。");
            public static readonly GUIContent highColorText = new GUIContent("高光", "高光：纹理（sRGB）×颜色（RGB） 默认：白色");
            public static readonly GUIContent highColorMaskText = new GUIContent("高光蒙版", "灰度纹理，利用其亮度来控制强度。");
            public static readonly GUIContent rimLightMaskText = new GUIContent("边缘光蒙版", "边缘光蒙版：纹理（线性）。纹理的白色部分显示为边缘光，黑色部分被掩蔽不显示。");
            public static readonly GUIContent matCapSamplerText = new GUIContent("MatCap贴图", "MatCap颜色：纹理（sRGB）×颜色（RGB） 默认：白色");
            public static readonly GUIContent matCapMaskText = new GUIContent("MatCap蒙版", "MatCap蒙版相对于MatCap投影到的网格的UV坐标定位，黑色区域的像素被隐藏。");
            public static readonly GUIContent angelRingText = new GUIContent("天使光环", "天使光环：纹理（sRGB）×颜色（RGB） 默认：黑色。");
            public static readonly GUIContent emissiveTexText = new GUIContent("发光贴图", "主要与泛光后期效果一起使用，可以表示发光的物体。");
            public static readonly GUIContent shadingGradeMapText = new GUIContent("阴影等级贴图", "在UV坐标中指定容易产生阴影的区域。阴影等级贴图：纹理（线性）");
            public static readonly GUIContent firstPositionMapText = new GUIContent("第一阴影位置贴图", "在UV坐标中指定位于第一阴影颜色区域中的固定阴影的位置。第一位置贴图：纹理（线性）");
            public static readonly GUIContent secondPositionMapText = new GUIContent("第二阴影位置贴图", "在UV坐标中指定位于第二阴影颜色区域中的固定阴影的位置。第二位置贴图：纹理（线性）");
            public static readonly GUIContent outlineSamplerText = new GUIContent("轮廓宽度贴图", "灰度纹理的轮廓宽度贴图：纹理（线性）。在白色情况下，轮廓宽度按原样显示。在黑色情况下，宽度为0。");
            public static readonly GUIContent outlineTexText = new GUIContent("轮廓颜色贴图", "轮廓纹理：纹理（sRGB） 默认：白色");
            public static readonly GUIContent bakedNormalOutlineText = new GUIContent("轮廓烘焙法线贴图", "未打包的法线贴图：纹理（线性）。请注意，这不是标准的法线贴图。");
            public static readonly GUIContent clippingMaskText = new GUIContent("剪切蒙版", "灰度纹理，利用其亮度来控制透明度。");

            public static readonly GUIContent specularModeText = new GUIContent("高光模式", "高光光照模式。硬或软。");
            public static readonly GUIContent specularBlendModeText = new GUIContent("颜色混合模式", "高光颜色混合模式。相乘或相加。");
            public static readonly GUIContent matcapBlendModeText = new GUIContent("颜色混合模式", "MatCap颜色混合模式。相乘或相加。");
            public static readonly GUIContent matcapOrthoText = new GUIContent("MatCap相机模式", "根据相机类型控制MatCap贴图的渲染方式。");
            public static readonly GUIContent transparentModeText = new GUIContent("透明度", "启用不同的模式，以模拟各种透明物体。");
            public static readonly GUIContent stencilVauleText = new GUIContent("模板值", "提交给模板缓冲区以控制每个像素的绘制。");
            public static readonly GUIContent workflowModeText = new GUIContent("模式", "控制在着色器中公开了哪些设置的UTS模式。");

            // -----------------------------------------------------
            public static readonly GUIContent clippingmodeModeText0 = new GUIContent("剪切", "允许使用纹理控制着色器的透明度。");
            public static readonly GUIContent clippingmodeModeText1 = new GUIContent("透明剪切", "选择适合您目的的透明剪切模式。");
            public static readonly GUIContent stencilmodeModeText = new GUIContent("模板", "控制操纵像素绘制的模板缓冲区。");
            public static readonly GUIContent cullingModeText = new GUIContent("剔除模式", "控制不应绘制（剔除）的多边形的侧面。");

            // ----------------------------------------------------- 用于GUI开关
            public static readonly GUIContent autoRenderQueueText = new GUIContent("自动渲染队列", "启用时，渲染顺序由系统自动确定。");
            public static readonly GUIContent renderQueueText = new GUIContent("渲染队列", "场景中的渲染顺序。");
            public static readonly GUIContent invertClippingMaskText = new GUIContent("反转剪切蒙版", "反转剪切蒙版的结果。");
            public static readonly GUIContent baseMapAlphaAsClippingMask = new GUIContent("使用基础贴图Alpha作为剪切蒙版", "使用基础贴图Alpha作为剪切蒙版，而不是剪切蒙版纹理。");
            public static readonly GUIContent applyTo1stShademapText = new GUIContent("应用于第一阴影贴图", "将基础贴图应用于第一阴影贴图。");
            public static readonly GUIContent applyTo2ndShademapText = new GUIContent("应用于第二阴影贴图", "将基础贴图或第一阴影贴图应用于第二阴影贴图。");
            public static readonly GUIContent threeBasicColorToNormalmapText = new GUIContent("三种基本颜色", "法线贴图对三种基本颜色区域，高光，第一阴影和第二阴影的影响。");
            public static readonly GUIContent highLightToNormalmapText = new GUIContent("高光", "法线贴图对高光区域的影响。");
            public static readonly GUIContent rimlightToNormalmapText = new GUIContent("边缘光", "法线贴图对边缘光区域的影响。");
            public static readonly GUIContent receiveShadowText = new GUIContent("接收阴影", "确定材质是否反射阴影。");
            public static readonly GUIContent filterPointLightText = new GUIContent("过滤点光源高光", "显示或隐藏点光源的高光。");
            public static readonly GUIContent highlightOnShadowText = new GUIContent("阴影中的高光混合", "控制阴影中高光的混合。");
            public static readonly GUIContent lightColorEffectiveness = EditorGUIUtility.TrTextContent("光色效果", "每个参数的光色效果。");

            public static readonly GUIContent lightColorEffectivinessToBaseColorText  = new GUIContent("基础颜色", "光的颜色对基础颜色区域的影响。");
            public static readonly GUIContent lightColorEffectivinessTo1stShadingText = new GUIContent("第一层阴影颜色", "光的颜色对第一层阴影颜色区域的影响。");
            public static readonly GUIContent lightColorEffectivinessTo2ndShadingText = new GUIContent("第二层阴影颜色", "光的颜色对第二层阴影颜色区域的影响。");
            public static readonly GUIContent lightColorEffectivinessToHighlitText    = new GUIContent("高光", "光的颜色对高光区域的影响。");
            public static readonly GUIContent lightColorEffectivinessToRimlitText     = new GUIContent("边缘光", "光的颜色对边缘光区域的影响。");
            public static readonly GUIContent lightColorEffectivinessToInvRimlitText  = new GUIContent("反向边缘光", "光的颜色对反向边缘光区域的影响。");
            public static readonly GUIContent lightColorEffectivinessToMatCapText = new GUIContent("MatCap", "光的颜色对MatCap区域的影响。");
            public static readonly GUIContent lightColorEffectivenessToAngelRingText = new GUIContent("天使光环", "光的颜色对天使光环区域的影响。天使光环仅在使用附加控制贴图模式时可用。");
            public static readonly GUIContent lightColorEffectivinessToOutlineText = new GUIContent("轮廓", "光的颜色对轮廓区域的影响。");
            public static readonly GUIContent rimlightText = new GUIContent("边缘光", "从模型背后照射并强调模型前部轮廓的光线。");
            public static readonly GUIContent rimlightFeatherText = new GUIContent("边缘光羽化关闭", "禁用边缘光羽化。");
            public static readonly GUIContent rimlightDirectionMaskText = new GUIContent("光的方向", "启用时，仅在光源方向上生成边缘光。");
            public static readonly GUIContent invertedRimlightText = new GUIContent("反向边缘光", "从反向/对脚方向产生的边缘光。");
            public static readonly GUIContent camearRollingStabilizerText = new GUIContent("稳定相机滚动", "捕捉相机材质时稳定相机滚动。");
            public static readonly GUIContent invertedRimlightFeatherText = new GUIContent("反向边缘光羽化关闭", "禁用反向边缘光羽化。");
            public static readonly GUIContent matCapText = new GUIContent("MatCap", "启用/禁用MatCap（材质捕捉）。");
            public static readonly GUIContent matCapNormalmapSpecularaMask = new GUIContent("MatCap的法线贴图镜面遮罩", "如果启用，专门为MatCap提供法线贴图。如果您将MatCap用作镜面照明，可以使用此选项进行遮罩。");
            public static readonly GUIContent matCapOnShadow = new GUIContent("阴影上的MatCap混合", "启用阴影中MatCap范围的混合速率。");
            public static readonly GUIContent invertMatCapMaskText = new GUIContent("反向MatCap蒙版", "启用时，反向MatCap蒙版纹理。");

            public static readonly GUIContent angelRingProjectionText = new GUIContent("天使光环投影", "为UTS启用天使光环效果，用于表现头发的光泽或光泽。");
            public static readonly GUIContent angelRingAlphaAdClippingMaskText = new GUIContent("Alpha通道作为裁剪蒙版", "使用纹理alpha通道作为裁剪蒙版。如果禁用，则alpha不会起作用。");
            public static readonly GUIContent pingpongMoveText = new GUIContent("基础的Ping-pong运动", "启用时，可以在动画方向上设置PingPong（前后摆动）。");
            public static readonly GUIContent colorShitWithTimeText = new GUIContent("随时间变化的颜色", "通过线性插值（Lerp）向目标颜色变化的Emissive纹理的颜色。");
            public static readonly GUIContent blendBaseColorToOutlineText = new GUIContent("视角变化的颜色变化", "发射颜色随视角变化而变化。");
            public static readonly GUIContent colorShiftWithViewAngle = new GUIContent("视角变化的颜色变化", "发射颜色随视角变化而变化。");
            public static readonly GUIContent baseColorToOtulineText = new GUIContent("将基础颜色混合到轮廓中", "将基础颜色混合到轮廓颜色中。");
            public static readonly GUIContent outlineColorMapText = new GUIContent("轮廓颜色映射", "将纹理应用为轮廓颜色映射。");
            public static readonly GUIContent bakedNormalForOutlineText = new GUIContent("轮廓的烘焙法线贴图", "使用从其他模型先前烘焙的顶点法线的法线贴图时，可以作为设置法线反演轮廓时的附加载入。");
            public static readonly GUIContent metaverseLightText = new GUIContent("Metaverse灯光", "启用UTS，使其在场景中没有定向光的情况下正常工作。");
            public static readonly GUIContent metaverseLightDirectionText = new GUIContent("Metaverse灯光方向", "控制场景中UTS的辅助照明方向。");
            public static readonly GUIContent invertZaxisDirection = new GUIContent("反向Z轴方向", "反向Metaverse灯光Z轴方向。");
            public static readonly GUIContent emissiveScrollAnimationModeText = new GUIContent("动画模式", "控制Emissive纹理的动画滚动。");
            public static readonly GUIContent emissionAnimationText = new GUIContent("发射贴图动画", "启用时，Emission贴图的UV和颜色会发生动画变化。");
            public static readonly GUIContent outlineModeText = new GUIContent("轮廓模式", "指定反向轮廓对象如何生成。");
            public static readonly GUIContent limitLightIntensityText = new GUIContent("限制光照强度", "限制光的亮度为1，以避免白色过曝。");

            // Range properties
public static readonly RangeProperty metaverseRangePropText = new RangeProperty(
                label: "元宇宙光强度", 
                tooltip: "控制场景中UTS补充照明的强度。",
                propName: ShaderPropUnlit_Intensity,  defaultValue: 0, min: 0.0f, max: 4.0f);
            public static readonly RangeProperty metaverseOffsettXaxisText = new RangeProperty(
                label: "X轴方向偏移", tooltip: "水平移动元宇宙光。",
                propName: "_Offset_X_Axis_BLD", defaultValue: -0.05f, min: -1.0f,max:1.0f);
            public static readonly RangeProperty metaverseOffsettYaxisText = new RangeProperty(
                label: "Y轴方向偏移", tooltip: "垂直移动元宇宙光。",
                propName: "_Offset_Y_Axis_BLD", defaultValue: -0.05f, min: -1.0f, max: 1.0f);
            public static readonly RangeProperty tweakTransParencyText = new RangeProperty(
                label: "透明度级别", tooltip: "通过考虑裁剪蒙版的灰度级别作为Alpha值来调整透明度。",
                propName: "_Tweak_transparency", defaultValue:0.0f, min: -1.0f, max:1.0f);
            public static readonly RangeProperty clippingLevelText = new RangeProperty(
                label: "裁剪级别", tooltip: "指定裁剪蒙版的强度。",
                propName: "_Clipping_Level", defaultValue: 0.0f,min: 0.0f, max: 1.0f);
            public static readonly RangeProperty scrollEmissiveUText = new RangeProperty(
                label: "滚动 U/X 方向", tooltip: "指定 Emissive 纹理在 u 方向（x 轴方向）更新动画时应滚动的程度。滚动动画最终由基础速度（时间）x 滚动 U 方向 x 滚动 V 方向确定。",
                propName: "_Scroll_EmissiveU", defaultValue: 0.0f, min: -1.0f, max: 1.0f);
            public static readonly RangeProperty scrollEmissiveVText = new RangeProperty(
                label: "滚动 V/Y 方向", tooltip: "指定 Emissive 纹理在 u 方向（y 轴方向）更新动画时应滚动的程度。滚动动画最终由基础速度（时间）x 滚动 U 方向 x 滚动 V 方向确定。",
                propName: "_Scroll_EmissiveV", defaultValue: 0.0f, min: -1.0f, max: 1.0f);
            public static readonly RangeProperty tweakHighColorOnShadowText = new RangeProperty(
                label: "混合级别", tooltip: "调整应用于阴影区域的高光的强度。",
                propName: "_TweakHighColorOnShadow", defaultValue: 0.0f, min: 0, max: 1);
            public static readonly RangeProperty tweakMatCapOnShadowText = new RangeProperty(
                label: "混合级别", tooltip: "调整应用于阴影区域的 MatCap 的强度。",
                propName: "_TweakMatCapOnShadow", defaultValue: 0.0f, min: 0, max: 1);
            public static readonly RangeProperty tweakSystemShadowLevelText = new RangeProperty(
                label: "系统阴影级别", tooltip: "定义与卡通着色器混合的自身阴影和其他接收到的阴影的外观。",
                propName: "_Tweak_SystemShadowsLevel", defaultValue: 0.0f, min: -0.5f, max: 0.5f);

            public static readonly RangeProperty shaderPropBaseColorText = new RangeProperty(
                label: "基础颜色步进", tooltip: "设置基础颜色和阴影颜色之间的边界。",
                propName: ShaderPropBaseColor_Step, defaultValue: 0.5f, min: 0, max: 1 );
            public static readonly RangeProperty shaderPropBaseFeatherText = new RangeProperty(
                label: "基础遮蔽羽化", tooltip: "羽化基础颜色和阴影颜色之间的边界。",
                propName: ShaderPropBaseShade_Feather, defaultValue: 0.0001f, min: 0.0001f, max: 1);
            public static readonly RangeProperty shaderPropShadeColorStepText = new RangeProperty(
                label: "阴影颜色步进", tooltip: "设置第1和第2阴影颜色之间的边界。如果不使用第2阴影颜色，则将其设置为0。",
                propName: ShaderPropShadeColor_Step, defaultValue: 0, min: 0, max: 1);
            public static readonly RangeProperty shaderProp1st2nd_Shades_FeatherText = new RangeProperty(
                label: "第1/2阴影羽化", tooltip: "羽化第1和第2阴影颜色之间的边界。",
                propName: ShaderProp1st2nd_Shades_Feather,defaultValue: 0.0001f, min: 0.0001f, max: 1);

            public static readonly RangeProperty shaderProp1st_ShadeColor_StepText = new RangeProperty(
                label: "第1阴影颜色步进", tooltip: "设置基色和第1阴影颜色之间的步进，与 BaseColor_Step 属性相同。",
                propName: ShaderProp1st_ShadeColor_Step, defaultValue: 0.5f, min: 0, max: 1);
            public static readonly RangeProperty shaderProp1st_ShadeColor_FeatherText = new RangeProperty(
                label: "第1阴影颜色羽化", tooltip: "羽化基础颜色和第1阴影颜色之间的边界，与 Base/Shade_Feather 属性相同。",
                propName: ShaderProp1st_ShadeColor_Feather,defaultValue: 0.0001f, min: 0.0001f, max: 1);
            public static readonly RangeProperty shaderProp2nd_ShadeColor_StepText = new RangeProperty(
                label: "第2阴影颜色步进", tooltip: "设置第1和第2阴影颜色之间的步进，与 ShadeColor_Step 属性相同。",
                propName: ShaderProp2nd_ShadeColor_Step, defaultValue: 0, min: 0, max: 1);
            public static readonly RangeProperty shaderProp2nd_ShadeColor_FeatherText = new RangeProperty(
                label: "第2阴影颜色羽化", tooltip: "羽化第1和第2阴影颜色之间的边界，与 1st/2nd_Shades_Feather 属性相同。",
                propName: ShaderProp2nd_ShadeColor_Feather, defaultValue: 0.0001f, min: 0.0001f, max: 1);

            public static readonly RangeProperty shaderPropStepOffsetText = new RangeProperty(
                label: "步进偏移", tooltip: "微调在 ForwardAdd 通道中添加的光步（边界），例如实时点光源。",
                propName: "_StepOffset", defaultValue:0, min: -0.5f, max: 0.5f);
            public static readonly RangeProperty shaderPropHilightPowerText = new RangeProperty(
                label: "高光强度", tooltip: "高光功率因子，着色器内部使用 pow(x,5)。",
                propName: "_HighColor_Power", defaultValue: 0, min: 0, max: 1);

            public static readonly RangeProperty hilightMaskLevelText = new RangeProperty(
                label: "高光蒙版级别", tooltip: "高光蒙版纹理混合到高光的级别。",
                propName: "_Tweak_HighColorMaskLevel", defaultValue: 0, min: -1, max: 1);

            public static readonly RangeProperty shadingGradeMapLevelText = new RangeProperty(
                label: "着色等级图级别", tooltip: "级别校正着色等级图中的灰度值。",
                propName: "_Tweak_ShadingGradeMapLevel", defaultValue: 0, min: -0.5f, max: 0.5f);

            public static readonly RangeProperty blureLevelSGMText = new RangeProperty(
                label: "着色等级图模糊级别", tooltip: "使用 Mip Map 功能模糊着色等级图；要启用 Mip Map，在纹理导入设置中打开高级 > 生成 Mip Map。默认值为 0（无模糊）。",
                propName: "_BlurLevelSGM", defaultValue: 0, min: 0, max: 10);

            public static readonly RangeProperty rimLightMaskLevelText = new RangeProperty(
                label: "边缘光蒙版级别", tooltip: "-1 表示边缘光效果为 0%，0 表示边缘光和蒙版效果为 100%，1 表示边缘光为 100%，蒙版效果为 0%。",
                propName: "_Tweak_RimLightMaskLevel", defaultValue: 0, min: -1, max: 1);

            public static readonly RangeProperty lightDirectionMaskLevelText = new RangeProperty(
                label: "灯光方向边缘光级别", tooltip: "指定灯光方向中的边缘光强度。",
                propName: "_Tweak_LightDirection_MaskLevel", defaultValue: 0, min: 0f, max: 0.5f);

            public static readonly RangeProperty tweakMatCapUVText = new RangeProperty(
                label: "调整 MatCap UV", tooltip: "缩放 MatCap Map 的 UV。",
                propName: "_Tweak_MatCapUV", defaultValue: 0, min: -0.5f, max: 0.5f);

            public static readonly RangeProperty rotateMatCapUVText = new RangeProperty(
                label: "旋转 MatCap UV", tooltip: "旋转 MatCap Map 的 UV。",
                propName: "_Rotate_MatCapUV", defaultValue: 0, min: -1, max: 1);

            public static readonly RangeProperty matcapBlurLevelText = new RangeProperty(
                label: "MatCap 模糊级别", tooltip: "使用 Mip Map 功能模糊 MatCap Map；要启用 Mip Map，在纹理导入设置中打开高级 > 生成 Mip Map。默认值为 0（无模糊）。",
                propName: "_BlurLevelMatcap", defaultValue: 0, min: 0, max: 10);

            public static readonly RangeProperty arOffsetU_Text = new RangeProperty(
                label: "U轴偏移", tooltip: "调整 Angel Ring 在水平方向的形状。",
                propName: "_AR_OffsetU", defaultValue: 0, min: 0, max: 0.5f);

            public static readonly RangeProperty arOffsetV_Text = new RangeProperty(
                label: "V轴偏移", tooltip: "调整 Angel Ring 在垂直方向的形状。",
                propName: "_AR_OffsetV", defaultValue: 0, min: 0, max: 1);

            public static readonly RangeProperty legacyTessEdgeLengthText = new RangeProperty(
                label: "边缘长度", tooltip: "根据相机距离进行细分。数值越小，瓦片越小。",
                propName: "_TessEdgeLength", defaultValue: 5, min: 2, max: 50);

            public static readonly RangeProperty legacyTessPhongStrengthText = new RangeProperty(
                label: "Phong 强度", tooltip: "调整曲面在细分时的牵引强度。",
                propName: "_TessPhongStrength", defaultValue: 0.5f, min: 0, max: 1);

            public static readonly RangeProperty legacyTessExtrusionAmountText = new RangeProperty(
                label: "挤出量", tooltip: "根据细分缩放扩展的部分。",
                propName: "_TessExtrusionAmount", defaultValue: 0.0f, min: -0.005f, max: 0.005f);

            public static readonly RangeProperty rimLightPowerText = new RangeProperty(
                label: "边缘光照级别", tooltip: "指定边缘光照强度。",
                propName: "_RimLight_Power", defaultValue:0.1f, min: 0, max: 1);

            public static readonly RangeProperty invertedRimLightPowerText = new RangeProperty(
                label: "反向边缘光照级别", tooltip: "指定反向/对极边缘光照级别。",
                propName: "_Ap_RimLight_Power", defaultValue: 0.1f, min: 0, max: 1);

            public static readonly RangeProperty giIntensityText = new RangeProperty(
                label: "光探针强度", tooltip: "根据GI强度值将光探针颜色添加到材质颜色。",
                propName: ShaderPropGI_Intensity, defaultValue: 0.0f, min: 0, max: 1);

            public static readonly RangeProperty tweakMatCapMaskLevelText = new RangeProperty(
                label: "MatCap 掩模级别", tooltip: "调整MatCap掩模的级别。当值为1时，MatCap将显示100%，无论是否存在掩模。当值为-1时，MatCap将完全不显示，与关闭状态下的MatCap相同。",
                propName: "_Tweak_MatcapMaskLevel",defaultValue:0.0f, min: -1, max: 1);

            public static readonly RangeProperty rotate_NormalMapForMatCapUVText = new RangeProperty(
                label: "旋转法线贴图UV", tooltip: "根据其中心旋转MatCap法线贴图UV。",
                propName: "_Rotate_NormalMapForMatCapUV", defaultValue: 0.0f, min: -1, max: 1);

            public static readonly RangeProperty rimLight_InsideMaskText = new RangeProperty(
                label: "调整边缘光区域", tooltip: "增加此值将缩小边缘光的影响区域。",
                propName: "_RimLight_InsideMask", defaultValue: 0.0001f, min: 0.0001f, max: 1);

            // Float properties
            public static readonly FloatProperty baseSpeedText = new FloatProperty(label: "基础速度（时间）", 
                tooltip: "指定滚动动画的基础更新速度。如果值为1，它将在1秒内更新。指定值为2将导致1值的两倍速度，因此它将在0.5秒内更新。",
                propName: "_Base_Speed", defaultValue: 0);

            public static readonly FloatProperty outlineWidthText = new FloatProperty(label: "轮廓宽度",
                tooltip: "指定轮廓的宽度。该值依赖于模型导入到Unity时的比例。",
                propName: "_Outline_Width", defaultValue: 0);

            public static readonly FloatProperty farthestDistanceText = new FloatProperty(label: "最远消失距离",
                tooltip: "指定最远的距离，轮廓宽度随摄像机和物体之间的距离变化。在这个距离上，轮廓将为零。",
                propName: "_Farthest_Distance", defaultValue: 100);

            public static readonly FloatProperty nearestDistanceText = new FloatProperty(label: "最近轮廓宽度距离",
                tooltip: "指定最近的距离，轮廓宽度随摄像机和物体之间的距离变化。在这个距离上，轮廓将为轮廓宽度设置的最大宽度。",
                propName: "_Nearest_Distance", defaultValue: 0.5f);

            public static readonly FloatProperty rotateEmissiveUVText = new FloatProperty(label: "绕UV中心旋转",
                tooltip: "当Base Speed=1时，发光纹理将顺时针旋转1。与滚动结合使用时，滚动后将发生旋转。",
                propName: "_Rotate_EmissiveUV", defaultValue: 0);

            public static readonly FloatProperty offsetZText = new FloatProperty(label: "使用相机Z轴偏移轮廓",
                tooltip: "在相机的深度（Z）方向上偏移轮廓。",
                propName: "_Offset_Z", defaultValue: 0);

            public static readonly FloatProperty colorShiftSpeedText = new FloatProperty(label: "颜色变化速度（时间）",
                tooltip: "设置颜色变化的参考速度。当值为1时，一个周期大约需要6秒。",
                propName: "_ColorShift_Speed", defaultValue: 0);

            // Color properties
            public static readonly ColorProperty viewShiftText = new ColorProperty(label: "变色目标颜色",
                tooltip: "上面的目标颜色，必须以HDR指定。",
                propName: "_ViewShift", isHDR: true);

            public static readonly ColorProperty colorShiftText = new ColorProperty(label: "目标颜色",
                tooltip: "上面的目标颜色，必须以HDR指定。",
                propName: "_ColorShift", isHDR: true);

            public static readonly ColorProperty rimLightColorText = new ColorProperty(label: "边缘光颜色",
                tooltip: "指定边缘光的颜色。",
                propName: "_RimLightColor", isHDR: false);

            public static readonly ColorProperty apRimLightColorText = new ColorProperty(label: "反向边缘光颜色",
                tooltip: "指定反向/对极边缘光的颜色。",
                propName: "_Ap_RimLightColor", isHDR: false);

            public static readonly ColorProperty outlineColorText = new ColorProperty(label: "轮廓颜色",
                tooltip: "指定轮廓的颜色。",
                propName: "_Outline_Color", isHDR: false);
        }
        // --------------------------------

        public UTS3GUI()
        {

        }

        public override void OnClosed(Material material)
        { 

            base.OnClosed(material);
        }
        
        void OnOpenGUI(Material material, MaterialEditor materialEditor, MaterialProperty[] props)
        {
            m_MaterialScopeList.RegisterHeaderScope(Styles.shaderFoldout, Expandable.Shader, DrawShaderOptions, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation:0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.basicColorFoldout, Expandable.Basic, GUI_BasicThreeColors, (uint)UTS_Mode.ThreeColorToon,(uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.shadingStepAndFeatherFoldout, Expandable.ShadingStepAndFeather, GUI_StepAndFeather, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.normalMapFoldout, Expandable.NormalMap, GUI_NormalmapSettings, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.highlightFoldout, Expandable.Highlight, GUI_HighlightSettings, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.rimLightFoldout, Expandable.Rimlight, GUI_RimLight, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.matCapFoldout, Expandable.MatCap, GUI_MatCap, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.angelRingFoldout, Expandable.AngelRing, GUI_AngelRing, (uint)UTS_Mode.ShadingGradeMap, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.emissionFoldout, Expandable.Emission, GUI_Emissive, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.outlineFoldout, Expandable.Outline, GUI_Outline, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.On, isTessellation: 0);

            m_MaterialScopeList.RegisterHeaderScope(Styles.tessellationFoldout, Expandable.TessellationLegacy, GUI_Tessellation, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 1);
            m_MaterialScopeList.RegisterHeaderScope(Styles.tessellationFoldout, Expandable.TessellationHDRP, GUI_TessellationHDRP, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 1);

            // originally these were in simple UI
            m_MaterialScopeList.RegisterHeaderScope(Styles.lightEffectivenessFoldout, Expandable.SceneLight, GUI_LightColorEffectiveness, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
            m_MaterialScopeList.RegisterHeaderScope(Styles.metaverseSettingsFoldout, Expandable.MetaverseSettings, GUI_MetaverseSettings, (uint)UTS_Mode.ThreeColorToon, (uint)UTS_TransparentMode.Off, isTessellation: 0);
        }

        void UTS3DrawHeaders(MaterialEditor materialEditor, Material material)
        {
            const string kTessellation = "Tessellation";
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            if (materialEditor == null)
                throw new ArgumentNullException(nameof(materialEditor));

            foreach (var item in m_MaterialScopeList.m_Items)
            {
                if ( !isShadingGrademap && item.workflowMode == (uint)UTS_Mode.ShadingGradeMap)
                {
                    continue;
                }
                if ( transparencyEnabled == UTS_TransparentMode.On && item.transparentEnabled == (uint)UTS_TransparentMode.On)
                {
                    continue;
                }
                if (item.tessellationEnabled == 1)
                {
                    if (currentRenderPipeline == RenderPipeline.HDRP)
                    {
                        if (item.expandable == (uint)Expandable.TessellationHDRP)
                        {
                            if (!material.shader.name.Contains(kTessellation))
                                continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (currentRenderPipeline == RenderPipeline.Legacy)
                    {
                        if (item.expandable == (uint)Expandable.TessellationLegacy)
                        {
                            if (!material.shader.name.Contains(kTessellation))
                                continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (currentRenderPipeline == RenderPipeline.Universal)
                    {
                        continue;
                    }
                }
                using (var header = new UTS3MaterialHeaderScope(
                    item.headerTitle,
                    item.expandable,
                    materialEditor,
                    defaultExpandedState: m_MaterialScopeList.m_DefaultExpandedState,
                    documentationURL: item.url))
        // never called from the system??
                {
                    if (!header.expanded)
                        continue;

                    item.drawMaterialScope(material);

                    EditorGUILayout.Space();
                }
            }


        }
        void ShaderPropertiesGUI(MaterialEditor materialEditor, Material material, MaterialProperty[] properties)
        {
            UTS3DrawHeaders(materialEditor, material);
        }

        void DrawShaderOptions(Material material)
        {
            GUI_SetCullingMode(material);
            GUI_SetRenderQueue(material);
            GUI_Tranparent(material);
            GUI_StencilMode(material);

            switch (m_WorkflowMode)
            {
                case UTS_Mode.ThreeColorToon:

                    DoPopup(Styles.clippingmodeModeText0, clippingMode, ClippingModeNames);
                    UTS_ClippingMode mode0 = (UTS_ClippingMode)MaterialGetInt(material, ShaderPropClippingMode);
                    EditorGUI.indentLevel++;
                    EditorGUI.BeginDisabledGroup(mode0 == UTS_ClippingMode.Off);
                    {
                        GUI_SetClippingMask(material);
                    }
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.BeginDisabledGroup(mode0 != UTS_ClippingMode.TransClippingMode);
                    {
                        GUI_SetTransparencySetting(material);
                    }
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.indentLevel--;
                    break;
                case UTS_Mode.ShadingGradeMap:

                    DoPopup(Styles.clippingmodeModeText1, clippingMode, System.Enum.GetNames(typeof(UTS_TransClippingMode)));
                    UTS_TransClippingMode mode1 = (UTS_TransClippingMode)MaterialGetInt(material, ShaderPropClippingMode);
                    EditorGUI.indentLevel++;
                    EditorGUI.BeginDisabledGroup(mode1 != UTS_TransClippingMode.On);
                    {
                        GUI_SetClippingMask(material);
                        GUI_SetTransparencySetting(material);
                    }
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.indentLevel--;
                    break;
            }

            EditorGUILayout.Space();

        }
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
        {

            m_MaterialEditor = materialEditor;
            Material material = materialEditor.target as Material;
            EditorGUIUtility.fieldWidth = 0;
            if (m_FirstTimeApply)
            {
                FindProperties(props);
                OnOpenGUI(material, materialEditor, props);
                m_FirstTimeApply = false;
            }

            UpdateVersionInMaterial(material);

            m_autoRenderQueue = MaterialGetInt(material,ShaderPropAutoRenderQueue);
            transparencyEnabled = (UTS_TransparentMode)MaterialGetInt(material,ShaderPropTransparentEnabled);
            stencilNumberSetting = MaterialGetInt(material,ShaderPropStencilNo);

            //Line 1 horizontal 3 buttons.
            EditorGUILayout.BeginHorizontal();
#if USE_SIMPLE_UI   // disabled SimpleUI
            //Original Inspector Selection Check.
            if (material.HasProperty(ShaderPropSimpleUI))
            {
                var selectedUI = material.GetInt(ShaderPropSimpleUI);
                if (selectedUI == 2)
                {
                    _OriginalInspector = true;  //Original GUI
                }
                else if (selectedUI == 1)
                {
                    _SimpleUI = true;   //UTS2 Beginner GUI
                }
                //Original/Custom GUI toggle button.
                if (_OriginalInspector)
                {
                    if (GUILayout.Button("Change CustomUI", middleButtonStyle))
                    {
                        _OriginalInspector = false;
                        MaterialSetInt(material,ShaderPropSimpleUI, 0); //UTS2 Pro GUI
                    }
                    OpenManualLink();
                    //Clear inherited layouts.
                    EditorGUILayout.EndHorizontal();
                    //Show Original GUI.
                    m_MaterialEditor.PropertiesDefaultGUI(props);
                    return;
                }
                if (GUILayout.Button("Show All properties", middleButtonStyle))
                {
                    _OriginalInspector = true;
                    MaterialSetInt(material,ShaderPropSimpleUI, 2); //Original GUI
                }
            }
#endif

            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();



            // select UTS technique here.
            DoPopup(Styles.workflowModeText, utsTechnique, UtsModeNames);
            m_WorkflowMode = (UTS_Mode)MaterialGetInt(material, ShaderPropUtsTechniqe);
            switch (m_WorkflowMode)
            {
                case UTS_Mode.ThreeColorToon:
                    material.DisableKeyword(ShaderDefineSHADINGGRADEMAP);
                    break;
                case UTS_Mode.ShadingGradeMap:
                    material.EnableKeyword(ShaderDefineSHADINGGRADEMAP);
                    break;
            }

            if (transparencyEnabled != UTS_TransparentMode.On)
            {
                SetupOutline(material);
            }
            else
            {
                SetupOverDrawTransparentObject(material);
            }
            ShaderPropertiesGUI(materialEditor, material, props);

            ApplyRenderingPerChennelsSetting(material);
            ApplyClippingMode(material);
            ApplyStencilMode(material);
            ApplyAngelRing(material);
            ApplyTessellation(material);
            ApplyMatCapMode(material);
            ApplyQueueAndRenderType(m_WorkflowMode, material);



            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.PropertiesChanged();
            }

        }// End of OnGUI()



        internal static int  MaterialGetInt(Material material, string prop )
        {
#if UNITY_2021_1_OR_NEWER
            return (int)material.GetFloat(prop);
#else
            return material.GetInt(prop);
#endif
        }
        internal static void MaterialSetInt(Material material, string prop, int value)
        {
#if UNITY_2021_1_OR_NEWER
            material.SetFloat(prop, value);
#else
            material.SetInt(prop, value);
#endif
        }
        bool GUI_ToggleShaderKeyword(Material material, string label, string keyword)
        {
            var isEnabled = material.IsKeywordEnabled(keyword);

            EditorGUI.BeginChangeCheck();
            var ret = EditorGUILayout.Toggle(label, isEnabled);
            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(label);
                if ( ret == false )
                {
                    material.DisableKeyword(keyword);
                }
                else
                {
                    material.EnableKeyword(keyword);
                }
            }
            return ret;
        }


        float GUI_FloatProperty(Material material, FloatProperty floatProp)
        {
            float ret = material.GetFloat(floatProp.m_propertyName);
            EditorGUI.BeginChangeCheck();
            ret = EditorGUILayout.FloatField(floatProp.m_GuiContent, ret );

            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(floatProp.m_GuiContent.text);
                material.SetFloat(floatProp.m_propertyName, ret);
            }
            return ret;
        }

        Color GUI_ColorProperty(Material material, ColorProperty colorProp)
        {
            Color ret = material.GetColor(colorProp.m_propertyName);
            EditorGUI.BeginChangeCheck();

            ret = EditorGUILayout.ColorField(colorProp.m_GuiContent, ret, showEyedropper: true, showAlpha: true, hdr: colorProp.m_isHDR);

            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(colorProp.m_GuiContent.text);
                material.SetColor(colorProp.m_propertyName, ret);
            }
            return ret;
        }
        float GUI_RangeProperty(Material material, RangeProperty rangeProp)
        {
            return GUI_RangeProperty(material, rangeProp.m_GuiContent, rangeProp.m_propertyName, rangeProp.m_Min, rangeProp.m_Max);
        }
        float GUI_RangeProperty(Material material, GUIContent guiContent, string propName,  float min, float max )
        {
            float ret = material.GetFloat(propName);
            EditorGUI.BeginChangeCheck();
            ret = EditorGUILayout.Slider(guiContent, ret, min, max );

            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(guiContent.text);
                material.SetFloat( propName, ret);
            }
            return ret;
        }

        bool GUI_Toggle(Material material, GUIContent guiContent, string prop, bool value)
        {
            EditorGUI.BeginChangeCheck();
            var ret = EditorGUILayout.Toggle(guiContent, value);
            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(guiContent.text);
                MaterialSetInt(material, prop, ret ? 1 : 0);
            }
            return ret;
        }

        // --------------------------------



        void GUI_SetRTHS(Material material)
        {

            EditorGUILayout.BeginHorizontal();


            var isRTHSenabled = GUI_ToggleShaderKeyword(material, "Raytraced Hard Shadow (deprecated)", ShaderDefineUTS_USE_RAYTRACING_SHADOW);

            EditorGUILayout.EndHorizontal();
            if (isRTHSenabled)
            {
                EditorGUILayout.LabelField("当启用此功能时，必须将 ShadowRaytracer 组件附加到相机上。");
            }
        }

        void GUI_SetRenderQueue(Material material)
        {

            EditorGUILayout.BeginHorizontal();

            m_autoRenderQueue = GUI_Toggle(material, Styles.autoRenderQueueText, ShaderPropAutoRenderQueue, m_autoRenderQueue == 1) ? 1 : 0;

            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(m_autoRenderQueue == 1);
            m_renderQueue = (int)EditorGUILayout.IntField(Styles.renderQueueText, material.renderQueue);
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;
        }


        void GUI_SetCullingMode(Material material)
        {
            const string _CullMode = "_CullMode";
            int _CullMode_Setting = MaterialGetInt(material,_CullMode);
            //Convert it to Enum format and store it in the offlineMode variable.
            if ((int)CullingMode.Off == _CullMode_Setting)
            {
                m_cullingMode = CullingMode.Off;
            }
            else if ((int)CullingMode.Frontface == _CullMode_Setting)
            {
                m_cullingMode = CullingMode.Frontface;
            }
            else
            {
                m_cullingMode = CullingMode.Backface;
            }
            //GUI description with EnumPopup.
            m_cullingMode = (CullingMode)EditorGUILayout.EnumPopup(Styles.cullingModeText, m_cullingMode);
            //If the value changes, write to the material.
            if (_CullMode_Setting != (int)m_cullingMode)
            {
                switch (m_cullingMode)
                {
                    case CullingMode.Off:
                        MaterialSetInt(material,_CullMode, 0);
                        break;
                    case CullingMode.Frontface:
                        MaterialSetInt(material,_CullMode, 1);
                        break;
                    default:
                        MaterialSetInt(material,_CullMode, 2);
                        break;
                }

            }


        }
        void GUI_Tranparent(Material material)
        {

            const string _ZWriteMode = "_ZWriteMode";
            const string _ZOverDrawMode = "_ZOverDrawMode";
            DoPopup(Styles.transparentModeText, transparentMode, System.Enum.GetNames(typeof(UTS_TransparentMode)));
            transparencyEnabled = (UTS_TransparentMode)MaterialGetInt(material, ShaderPropTransparentEnabled);

            if (transparencyEnabled == UTS_TransparentMode.On)
            {
                if (MaterialGetInt(material,ShaderPropUtsTechniqe) == (int)UTS_Mode.ThreeColorToon)
                {
                    MaterialSetInt(material,ShaderPropClippingMode, (int)UTS_ClippingMode.TransClippingMode);
                }
                else
                {
                    // ShadingGradeMap
                    MaterialSetInt(material,ShaderPropClippingMode, (int)UTS_TransClippingMode.On);
                }
                MaterialSetInt(material,_ZWriteMode, 0);
                material.SetFloat(_ZOverDrawMode, 1);
            }
            else
            {
                MaterialSetInt(material,_ZWriteMode, 1);
                material.SetFloat(_ZOverDrawMode, 0);
            }

        }

        void GUI_StencilMode(Material material)
        {
            const string kStencilValue = "Stencil Value";

            DoPopup(Styles.stencilmodeModeText, stencilMode, StencilModeNames );


            EditorGUI.indentLevel++;
            int currentStencilValue = stencilNumberSetting;
            EditorGUI.BeginDisabledGroup((UTS_StencilMode)MaterialGetInt(material, ShaderPropStencilMode) == UTS_StencilMode.Off);
            EditorGUI.BeginChangeCheck();
            currentStencilValue = EditorGUILayout.IntSlider(Styles.stencilVauleText, stencilNumberSetting, 0, 255);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(material, "Changed " + kStencilValue);
                MaterialSetInt(material, ShaderPropStencilNo, currentStencilValue);
            }

            EditorGUI.EndDisabledGroup();

            EditorGUI.indentLevel--;
        }

        void GUI_SetClippingMask(Material material)
        {
            m_MaterialEditor.TexturePropertySingleLine(Styles.clippingMaskText, clippingMask);

            GUI_Toggle(material, Styles.invertClippingMaskText, ShaderPropInverseClipping,MaterialGetInt(material, ShaderPropInverseClipping)!= 0 );
            GUI_RangeProperty(material, Styles.clippingLevelText);
        }

        void GUI_SetTransparencySetting(Material material)
        {
            GUI_RangeProperty(material, Styles.tweakTransParencyText );
            GUI_Toggle(material, Styles.baseMapAlphaAsClippingMask, ShaderPropIsBaseMapAlphaAsClippingMask, MaterialGetInt(material, ShaderPropIsBaseMapAlphaAsClippingMask) != 0);
        }




        void GUI_BasicThreeColors(Material material)
        {


            m_MaterialEditor.TexturePropertySingleLine(Styles.baseColorText, mainTex, baseColor);
            //v.2.0.7 Synchronize _Color to _BaseColor.
            if (material.HasProperty("_Color"))
            {
                material.SetColor("_Color", material.GetColor("_BaseColor"));
            }
            //

            EditorGUI.indentLevel += 2;
            var applyTo1st = GUI_Toggle(material, Styles.applyTo1stShademapText, ShaderPropUse_BaseAs1st, MaterialGetInt(material, ShaderPropUse_BaseAs1st) != 0);
            EditorGUI.indentLevel -= 2;





            if (applyTo1st)
            {

                EditorGUI.indentLevel += 2;
                m_MaterialEditor.ColorProperty( firstShadeColor, Styles.firstShadeColorText.text);
                EditorGUI.indentLevel -= 2;

            }
            else
            {
                m_MaterialEditor.TexturePropertySingleLine(Styles.firstShadeColorText, firstShadeMap, firstShadeColor);
            }
            //            EditorGUI.EndDisabledGroup();

            EditorGUI.indentLevel+=2;
            var applyTo2nd =  GUI_Toggle(material, Styles.applyTo2ndShademapText, ShaderPropUse_1stAs2nd, MaterialGetInt(material, ShaderPropUse_1stAs2nd) != 0);
            EditorGUI.indentLevel-=2;


            if (applyTo2nd)
            {
                EditorGUI.indentLevel += 2;
                m_MaterialEditor.ColorProperty(secondShadeColor, Styles.secondShadeColorText.text);
                EditorGUI.indentLevel -= 2;
            }
            else
            {
                m_MaterialEditor.TexturePropertySingleLine(Styles.secondShadeColorText, secondShadeMap, secondShadeColor);
            }
            EditorGUILayout.Space();

            /*
            _NormalMap_Foldout = FoldoutSubMenu(_NormalMap_Foldout, Styles.normalMapFoldout);
            if (_NormalMap_Foldout)
            {
            }
            */
            _ShadowControlMaps_Foldout = FoldoutSubMenu(_ShadowControlMaps_Foldout, Styles.shadowControlMapFoldout);
            if (_ShadowControlMaps_Foldout)
            {
                EditorGUI.indentLevel++;
                GUI_ShadowControlMaps(material);
                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }
        }

        void GUI_ShadowControlMaps(Material material)
        {
            if (material.HasProperty(ShaderPropUtsTechniqe))//DoubleWithFeather or ShadingGradeMap
            {
                if (MaterialGetInt(material,ShaderPropUtsTechniqe) == (int)UTS_Mode.ThreeColorToon)   //DWF
                {
                    EditorGUILayout.LabelField("模式：标准", EditorStyles.boldLabel);
                    m_MaterialEditor.TexturePropertySingleLine(Styles.firstPositionMapText, set_1st_ShadePosition);
                    m_MaterialEditor.TexturePropertySingleLine(Styles.secondPositionMapText, set_2nd_ShadePosition);
                }
                else if (MaterialGetInt(material,ShaderPropUtsTechniqe) == (int)UTS_Mode.ShadingGradeMap)
                {    
                    EditorGUILayout.LabelField("模式：带附加控制图", EditorStyles.boldLabel);
                    m_MaterialEditor.TexturePropertySingleLine(Styles.shadingGradeMapText, shadingGradeMap);
                    GUI_RangeProperty(material, Styles.shadingGradeMapLevelText);
                    GUI_RangeProperty(material, Styles.blureLevelSGMText);
                }
            }
        }

        void GUI_StepAndFeather(Material material)
        {
            GUI_ShadingStepAndFeatherSettings(material);

            if (!_SimpleUI)
            {
                GUI_SystemShadows(material);

                _AdditionalLookdevs_Foldout = FoldoutSubMenu(_AdditionalLookdevs_Foldout, Styles.pointLightFoldout);
                if (_AdditionalLookdevs_Foldout)
                {
                    GUI_AdditionalLookdevs(material);
                }

            }
        }

        void GUI_SystemShadows(Material material)
        {
            bool isEnabled = GUI_Toggle(material, Styles.receiveShadowText, ShaderPropSetSystemShadowsToBase, MaterialGetInt(material,ShaderPropSetSystemShadowsToBase) != 0);

            //           if (material.GetFloat(ShaderPropSetSystemShadowsToBase) == 1)
            EditorGUI.BeginDisabledGroup(!isEnabled);
            {
                EditorGUI.indentLevel++;
                GUI_RangeProperty(material, Styles.tweakSystemShadowLevelText);

                if (UnityToonShaderSettings.instance.m_ShowDepracated)
                {
                    GUI_SetRTHS(material);
                }
                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();
        }

        void GUI_ShadingStepAndFeatherSettings(Material material)
        {
            if (material.HasProperty(ShaderPropUtsTechniqe))
            {
                var mode = MaterialGetInt(material, ShaderPropUtsTechniqe);
                if (mode == (int)UTS_Mode.ThreeColorToon)   
                {
                    EditorGUILayout.LabelField("模式：标准", EditorStyles.boldLabel);
                    GUI_RangeProperty(material, Styles.shaderPropBaseColorText);
                    GUI_RangeProperty(material, Styles.shaderPropBaseFeatherText);
                    GUI_RangeProperty(material, Styles.shaderPropShadeColorStepText);
                    GUI_RangeProperty(material, Styles.shaderProp1st2nd_Shades_FeatherText);
                    

                    //Sharing variables with ShadingGradeMap method.

                    material.SetFloat(ShaderProp1st_ShadeColor_Step, material.GetFloat(ShaderPropBaseColor_Step));
                    material.SetFloat(ShaderProp1st_ShadeColor_Feather, material.GetFloat(ShaderPropBaseShade_Feather));
                    material.SetFloat(ShaderProp2nd_ShadeColor_Step, material.GetFloat(ShaderPropShadeColor_Step));
                    material.SetFloat(ShaderProp2nd_ShadeColor_Feather, material.GetFloat(ShaderProp1st2nd_Shades_Feather));
                }
                else if (mode == (int)UTS_Mode.ShadingGradeMap)
                {    //SGM
                    EditorGUILayout.LabelField("模式：带附加控制图", EditorStyles.boldLabel);

                    GUI_RangeProperty(material, Styles.shaderProp1st_ShadeColor_StepText);
                    GUI_RangeProperty(material, Styles.shaderProp1st_ShadeColor_FeatherText);
                    GUI_RangeProperty(material, Styles.shaderProp2nd_ShadeColor_StepText);
                    GUI_RangeProperty(material, Styles.shaderProp2nd_ShadeColor_FeatherText);

                    //Share variables with DoubleWithFeather method.
                    material.SetFloat(ShaderPropBaseColor_Step, material.GetFloat(ShaderProp1st_ShadeColor_Step));
                    material.SetFloat(ShaderPropBaseShade_Feather, material.GetFloat(ShaderProp1st_ShadeColor_Feather));
                    material.SetFloat(ShaderPropShadeColor_Step, material.GetFloat(ShaderProp2nd_ShadeColor_Step));
                    material.SetFloat(ShaderProp1st2nd_Shades_Feather, material.GetFloat(ShaderProp2nd_ShadeColor_Feather));
                }
                else
                {
                    // OutlineObj.
                    return;
                }
            }
            EditorGUILayout.Space();
        }

        void GUI_AdditionalLookdevs(Material material)
        {

            EditorGUI.indentLevel++;
            GUI_RangeProperty(material, Styles.shaderPropStepOffsetText);
            GUI_Toggle(material, Styles.filterPointLightText, ShaderPropIsFilterHiCutPointLightColor, MaterialGetInt(material, ShaderPropIsFilterHiCutPointLightColor) != 0);

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
        }

        void GUI_NormalmapSettings(Material material)
        {

            m_MaterialEditor.TexturePropertySingleLine(Styles.normalMapText, normalMap, bumpScale);
            m_MaterialEditor.TextureScaleOffsetProperty(normalMap);

            EditorGUILayout.LabelField("法线贴图有效性", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            GUI_Toggle(material, Styles.threeBasicColorToNormalmapText, ShaderPropIs_NormalMapToBase, MaterialGetInt(material, ShaderPropIs_NormalMapToBase) != 0);
            GUI_Toggle(material, Styles.highLightToNormalmapText, ShaderPropNormalMapToHighColor, MaterialGetInt(material, ShaderPropNormalMapToHighColor) != 0);
            GUI_Toggle(material, Styles.rimlightToNormalmapText, ShaderPropIsNormalMapToRimLight, MaterialGetInt(material, ShaderPropIsNormalMapToRimLight) != 0);

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

        }
        void GUI_HighlightSettings(Material material)
        {
            m_MaterialEditor.TexturePropertySingleLine(Styles.highColorText, highColor_Tex, highColor);
            GUI_RangeProperty(material, Styles.shaderPropHilightPowerText);

            if (!_SimpleUI)
            {

                EditorGUI.showMixedValue = specularMode.hasMixedValue;

                int mode = (int)specularMode.floatValue;
                EditorGUI.BeginChangeCheck();
                mode = EditorGUILayout.Popup(Styles.specularModeText, mode, System.Enum.GetNames(typeof(UTS_SpeculerMode)));
                if (EditorGUI.EndChangeCheck())
                {
                    m_MaterialEditor.RegisterPropertyChangeUndo(Styles.specularModeText.text);
                    switch ((UTS_SpeculerMode)mode)
                    {
                    case UTS_SpeculerMode.Hard:
                        break;
                    case UTS_SpeculerMode.Soft:
                        specularBlendMode.floatValue = 1.0f;
                        break;
                    }


                    specularMode.floatValue = mode;
                }
                EditorGUI.showMixedValue = false;


                EditorGUILayout.BeginHorizontal();
                EditorGUI.indentLevel++;

                //GUILayout.Space(60);
                EditorGUI.BeginDisabledGroup(mode != 0);
                EditorGUI.showMixedValue = specularBlendMode.hasMixedValue;
                int blendingMode = (int)specularBlendMode.floatValue;
                EditorGUI.BeginChangeCheck();
                blendingMode = EditorGUILayout.Popup(Styles.specularBlendModeText, blendingMode, System.Enum.GetNames(typeof(UTS_SpeculerColorBlendMode)));
                if (EditorGUI.EndChangeCheck())
                {
                    m_MaterialEditor.RegisterPropertyChangeUndo(Styles.specularModeText.text);
                    specularBlendMode.floatValue = blendingMode;
                }
                EditorGUI.indentLevel--;
                EditorGUILayout.EndHorizontal();
                EditorGUI.showMixedValue = false;
                EditorGUI.EndDisabledGroup();


                var ret = GUI_Toggle(material, Styles.highlightOnShadowText, ShaderPropIs_UseTweakHighColorOnShadow, MaterialGetInt(material, ShaderPropIs_UseTweakHighColorOnShadow) != 0);
                EditorGUI.BeginDisabledGroup(!ret);
                {
                    EditorGUI.indentLevel++;
                    GUI_RangeProperty(material, Styles.tweakHighColorOnShadowText);
                    EditorGUI.indentLevel--;
                }
                EditorGUI.EndDisabledGroup();

            }

            EditorGUILayout.Space();
            //Line();
            //EditorGUILayout.Space();

            EditorGUILayout.LabelField("高光蒙版", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            m_MaterialEditor.TexturePropertySingleLine(Styles.highColorMaskText, set_HighColorMask);
            GUI_RangeProperty(material, Styles.hilightMaskLevelText);
            
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
        }

        void GUI_RimLight(Material material)
        {

            EditorGUILayout.BeginHorizontal();
            var rimLightEnabled = GUI_Toggle(material, Styles.rimlightText, ShaderPropRimLight, MaterialGetInt(material, ShaderPropRimLight) != 0);
            EditorGUILayout.EndHorizontal();
            EditorGUI.BeginDisabledGroup(!rimLightEnabled);
            EditorGUI.indentLevel++;

            GUI_ColorProperty(material, Styles.rimLightColorText);
            GUI_RangeProperty(material, Styles.rimLightPowerText);

            if (!_SimpleUI)
            {
                GUI_RangeProperty(material, Styles.rimLight_InsideMaskText);

                EditorGUILayout.BeginHorizontal();
                GUI_Toggle(material, Styles.rimlightFeatherText, ShaderPropRimLight_FeatherOff, MaterialGetInt(material, ShaderPropRimLight_FeatherOff) != 0);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                //GUILayout.Space(60);
                var direcitonMaskEnabled = GUI_Toggle(material, Styles.rimlightDirectionMaskText, ShaderPropLightDirection_MaskOn, MaterialGetInt(material, ShaderPropLightDirection_MaskOn) != 0);
                EditorGUILayout.EndHorizontal();

                EditorGUI.BeginDisabledGroup(!direcitonMaskEnabled);
                {
                    EditorGUI.indentLevel++;
                    GUI_RangeProperty(material, Styles.lightDirectionMaskLevelText);

                    EditorGUILayout.BeginHorizontal();
                    var antipodean_RimLight = GUI_Toggle(material, Styles.invertedRimlightText, ShaderPropAdd_Antipodean_RimLight, MaterialGetInt(material, ShaderPropAdd_Antipodean_RimLight )!= 0);
                    EditorGUILayout.EndHorizontal();

                    EditorGUI.BeginDisabledGroup(!antipodean_RimLight);
                    {
                        EditorGUI.indentLevel++;
                        GUI_ColorProperty(material, Styles.apRimLightColorText);
                        GUI_RangeProperty(material, Styles.invertedRimLightPowerText);

                        EditorGUILayout.BeginHorizontal();
                        GUI_Toggle(material, Styles.invertedRimlightFeatherText, ShaderPropAp_RimLight_FeatherOff, MaterialGetInt(material, ShaderPropAp_RimLight_FeatherOff) != 0);


                        EditorGUILayout.EndHorizontal();
                        EditorGUI.indentLevel--;
                    }
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.indentLevel--;

                }//Light Direction Mask ON
                EditorGUI.EndDisabledGroup();
            }

            //EditorGUI.indentLevel++;

            EditorGUILayout.Space();
            //Line();
            //EditorGUILayout.Space();

            m_MaterialEditor.TexturePropertySingleLine(Styles.rimLightMaskText, set_RimLightMask);
            GUI_RangeProperty(material, Styles.rimLightMaskLevelText);

            //EditorGUI.indentLevel--;

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            EditorGUI.EndDisabledGroup();




        }

        void GUI_MatCap(Material material)
        {
            EditorGUILayout.BeginHorizontal();
            var matcapEnabled = GUI_Toggle(material, Styles.matCapText, ShaderPropMatCap,MaterialGetInt(material, ShaderPropMatCap) != 0);
            EditorGUILayout.EndHorizontal();
            EditorGUI.BeginDisabledGroup(!matcapEnabled);

            m_MaterialEditor.TexturePropertySingleLine(Styles.matCapSamplerText, matCap_Sampler, matCapColor);
            EditorGUI.indentLevel++;
            m_MaterialEditor.TextureScaleOffsetProperty(matCap_Sampler);

            if (!_SimpleUI)
            {

                GUI_RangeProperty(material, Styles.matcapBlurLevelText);
                EditorGUILayout.BeginHorizontal();
                DoPopup(Styles.matcapBlendModeText, matcapBlendMode, System.Enum.GetNames(typeof(UTS_MatcapColorBlendMode)));
                EditorGUILayout.EndHorizontal();

                GUI_RangeProperty(material, Styles.tweakMatCapUVText);
                GUI_RangeProperty(material, Styles.rotateMatCapUVText);

                EditorGUILayout.BeginHorizontal();
                GUI_Toggle(material, Styles.camearRollingStabilizerText, ShaderPropCameraRolling_Stabilizer, MaterialGetInt(material, ShaderPropCameraRolling_Stabilizer) != 0);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                var isNormalMapForMatCap = GUI_Toggle(material, Styles.matCapNormalmapSpecularaMask, ShaderPropIs_NormalMapForMatCap, MaterialGetInt(material, ShaderPropIs_NormalMapForMatCap) != 0);

                //GUILayout.Space(60);

                EditorGUILayout.EndHorizontal();
                EditorGUI.BeginDisabledGroup(!isNormalMapForMatCap);
                {
                    EditorGUI.indentLevel++;
                    m_MaterialEditor.TexturePropertySingleLine(Styles.normalMapText, normalMapForMatCap, bumpScaleMatcap);
                    m_MaterialEditor.TextureScaleOffsetProperty(normalMapForMatCap);
                    GUI_RangeProperty(material, Styles.rotate_NormalMapForMatCapUVText);
                    EditorGUI.indentLevel--;
                }
                EditorGUI.EndDisabledGroup();

                EditorGUILayout.BeginHorizontal();
                var tweakMatCapOnShadows = GUI_Toggle(material, Styles.matCapOnShadow, ShaderPropIs_UseTweakMatCapOnShadow, MaterialGetInt(material, ShaderPropIs_UseTweakMatCapOnShadow) != 0);
 
                EditorGUILayout.EndHorizontal();
                EditorGUI.BeginDisabledGroup(!tweakMatCapOnShadows);
                {
                    EditorGUI.indentLevel++;
                    GUI_RangeProperty(material, Styles.tweakMatCapOnShadowText);
                    EditorGUI.indentLevel--;
                }
                EditorGUI.EndDisabledGroup();
                DoPopup(Styles.matcapOrthoText, matcapCameraMode, System.Enum.GetNames(typeof(CameraProjectionType)));
            }

            EditorGUILayout.Space();
            //Line();
            //EditorGUILayout.Space();

            EditorGUILayout.LabelField("材质球捕获蒙版", EditorStyles.boldLabel);
            m_MaterialEditor.TexturePropertySingleLine(Styles.matCapMaskText, set_MatcapMask);
            m_MaterialEditor.TextureScaleOffsetProperty(set_MatcapMask);
            GUI_RangeProperty(material, Styles.tweakMatCapMaskLevelText);

            GUI_Toggle(material, Styles.invertMatCapMaskText, ShaderPropInvert_MatcapMask, MaterialGetInt(material, ShaderPropInvert_MatcapMask) != 0);


            EditorGUI.indentLevel--;

            EditorGUI.EndDisabledGroup();


            //EditorGUILayout.Space();
        }

        void GUI_AngelRing(Material material)
        {
            var angelRingEnabled = GUI_Toggle(material, Styles.angelRingProjectionText, ShaderPropAngelRing, MaterialGetInt(material, ShaderPropAngelRing) != 0);
            EditorGUI.BeginDisabledGroup(!angelRingEnabled);
            {
                m_MaterialEditor.TexturePropertySingleLine(Styles.angelRingText, angelRing_Sampler, angelRing_Color);
                EditorGUI.indentLevel++;
                //m_MaterialEditor.TextureScaleOffsetProperty(angelRing_Sampler);
                GUI_RangeProperty(material, Styles.arOffsetU_Text);
                GUI_RangeProperty(material, Styles.arOffsetV_Text);

                GUI_Toggle(material, Styles.angelRingAlphaAdClippingMaskText, ShaderPropARSampler_AlphaOn, MaterialGetInt(material, ShaderPropARSampler_AlphaOn) != 0);

                EditorGUI.indentLevel--;

            }
            EditorGUI.EndDisabledGroup();
        }
        void ApplyQueueAndRenderType(UTS_Mode technique, Material material)
        {

            if (m_autoRenderQueue == 1)
            {
                 material.renderQueue = -1; //  (int)UnityEngine.Rendering.RenderQueue.Geometry;
            }

            const string OPAQUE = "Opaque";
            const string TRANSPARENTCUTOUT = "TransparentCutOut";
            const string TRANSPARENT = "Transparent";
            const string RENDERTYPE = "RenderType";
            const string IGNOREPROJECTION = "IgnoreProjection";
            const string DO_IGNOREPROJECTION = "True";
            const string DONT_IGNOREPROJECTION = "False";
            var renderType = OPAQUE;
            var ignoreProjection = DONT_IGNOREPROJECTION;

            if (transparencyEnabled == UTS_TransparentMode.On)
            {
                renderType = TRANSPARENT;
                ignoreProjection = DO_IGNOREPROJECTION;
            }
            else
            {
                switch (technique)
                {
                    case UTS_Mode.ThreeColorToon:
                        {
                            UTS_ClippingMode clippingMode = (UTS_ClippingMode)MaterialGetInt(material,ShaderPropClippingMode);
                            if (clippingMode == UTS_ClippingMode.Off)
                            {

                            }
                            else
                            {
                                renderType = TRANSPARENTCUTOUT;

                            }

                            break;
                        }
                    case UTS_Mode.ShadingGradeMap:
                        {
                            UTS_TransClippingMode transClippingMode = (UTS_TransClippingMode)MaterialGetInt(material,ShaderPropClippingMode);
                            if (transClippingMode == UTS_TransClippingMode.Off)
                            {
                            }
                            else
                            {
                                renderType = TRANSPARENTCUTOUT;

                            }

                            break;
                        }
                }

            }
            if (m_autoRenderQueue == 1)
            {
                SetReqnderQueueAuto(material);
            }
            else
            {
                material.renderQueue = m_renderQueue;
            }

            material.SetOverrideTag(RENDERTYPE, renderType);
            material.SetOverrideTag(IGNOREPROJECTION, ignoreProjection);
        }

        void SetReqnderQueueAuto(Material material)
        {
            var stencilMode = (UTS_StencilMode)MaterialGetInt(material,ShaderPropStencilMode);
            if (transparencyEnabled == UTS_TransparentMode.On)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            }
            else if (stencilMode == UTS_StencilMode.StencilMask)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest - 1;
            }
            else if (stencilMode == UTS_StencilMode.StencilOut)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest;
            }
            if (transparencyEnabled == UTS_TransparentMode.On)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            }
            else if (stencilMode == UTS_StencilMode.StencilMask)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest - 1;
            }
            else if (stencilMode == UTS_StencilMode.StencilOut)
            {
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest;
            }
        }
        void ApplyMatCapMode(Material material)
        {
            if (MaterialGetInt(material,ShaderPropClippingMode) == 0)
            {
                if (material.GetFloat(ShaderPropMatCap) == 1)
                    material.EnableKeyword(ShaderPropMatCap);
                else
                    material.DisableKeyword(ShaderPropMatCap);
            }
            else
            {
                material.DisableKeyword(ShaderPropMatCap);
            }
        }


        void ApplyAngelRing(Material material)
        {
            int angelRingEnabled = MaterialGetInt(material,ShaderPropAngelRing);
            if (angelRingEnabled == 0)
            {
                material.DisableKeyword(ShaderDefineANGELRING_ON);
                material.EnableKeyword(ShaderDefineANGELRING_OFF);
            }
            else
            {
                material.EnableKeyword(ShaderDefineANGELRING_ON);
                material.DisableKeyword(ShaderDefineANGELRING_OFF);

            }
        }

        void ApplyStencilMode(Material material)
        {
            UTS_StencilMode mode = (UTS_StencilMode)(MaterialGetInt(material,ShaderPropStencilMode));
            switch (mode)
            {
                case UTS_StencilMode.Off:
                    MaterialSetInt(material,ShaderPropStencilComp, (int)StencilCompFunction.Disabled);
                    MaterialSetInt(material, ShaderPropStencilOpPass, (int)StencilOperation.Keep);
                    MaterialSetInt(material, ShaderPropStencilOpFail, (int)StencilOperation.Keep);
                    break;
                case UTS_StencilMode.StencilMask:
                     MaterialSetInt(material, ShaderPropStencilComp, (int)StencilCompFunction.Always);
                    MaterialSetInt(material, ShaderPropStencilOpPass, (int)StencilOperation.Replace);
                    MaterialSetInt(material, ShaderPropStencilOpFail, (int)StencilOperation.Replace);
                    break;
                case UTS_StencilMode.StencilOut:
                    MaterialSetInt(material, ShaderPropStencilComp, (int)StencilCompFunction.NotEqual);
                    MaterialSetInt(material, ShaderPropStencilOpPass, (int)StencilOperation.Keep);
                    MaterialSetInt(material, ShaderPropStencilOpFail, (int)StencilOperation.Keep);

                    break;
            }



        }
        void ApplyClippingMode(Material material)
        {

            if (!isShadingGrademap)
            {


                material.DisableKeyword(ShaderDefineIS_TRANSCLIPPING_OFF);
                material.DisableKeyword(ShaderDefineIS_TRANSCLIPPING_ON);

                switch ((UTS_ClippingMode)MaterialGetInt(material,ShaderPropClippingMode))
                {
                    case UTS_ClippingMode.Off:
                        material.EnableKeyword(ShaderDefineIS_CLIPPING_OFF);
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_MODE);
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_TRANSMODE);
                        material.EnableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_NO);
                        material.DisableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_YES);
                        break;
                    case UTS_ClippingMode.On:
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_OFF);
                        material.EnableKeyword(ShaderDefineIS_CLIPPING_MODE);
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_TRANSMODE);
                        material.DisableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_NO);
                        material.EnableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_YES);
                        break;
                    default: // UTS_ClippingMode.TransClippingMode
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_OFF);
                        material.DisableKeyword(ShaderDefineIS_CLIPPING_MODE);
                        material.EnableKeyword(ShaderDefineIS_CLIPPING_TRANSMODE);
                        material.DisableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_NO);
                        material.EnableKeyword(ShaderDefineIS_OUTLINE_CLIPPING_YES);
                        break;
                }
            }
            else
            {


                material.DisableKeyword(ShaderDefineIS_CLIPPING_OFF);
                material.DisableKeyword(ShaderDefineIS_CLIPPING_MODE);
                material.DisableKeyword(ShaderDefineIS_CLIPPING_TRANSMODE);
                switch ((UTS_TransClippingMode)MaterialGetInt(material,ShaderPropClippingMode))
                {
                    case UTS_TransClippingMode.Off:
                        material.EnableKeyword(ShaderDefineIS_TRANSCLIPPING_OFF);
                        material.DisableKeyword(ShaderDefineIS_TRANSCLIPPING_ON);
                        break;
                    default:
                        material.DisableKeyword(ShaderDefineIS_TRANSCLIPPING_OFF);
                        material.EnableKeyword(ShaderDefineIS_TRANSCLIPPING_ON);
                        break;

                }

            }

        }
        void GUI_Emissive(Material material)
        {

            m_MaterialEditor.TexturePropertySingleLine(Styles.emissiveTexText, emissive_Tex, emissive_Color);
            m_MaterialEditor.TextureScaleOffsetProperty(emissive_Tex);

            int _EmissiveMode_Setting = MaterialGetInt(material,"_EMISSIVE");
            if ((int)EmissionMode.SimpleEmissive == _EmissiveMode_Setting)
            {
                m_emissionMode = EmissionMode.SimpleEmissive;
            }
            else if ((int)EmissionMode.EmissiveAnimation == _EmissiveMode_Setting)
            {
                m_emissionMode = EmissionMode.EmissiveAnimation;
            }
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();

            var ret = EditorGUILayout.Toggle(Styles.emissionAnimationText, m_emissionMode != EmissionMode.SimpleEmissive);
            if (EditorGUI.EndChangeCheck())
            {
                m_MaterialEditor.RegisterPropertyChangeUndo(Styles.emissionAnimationText.text);
                if (ret )
                {
                    material.SetFloat("_EMISSIVE", 1);
                    material.EnableKeyword("_EMISSIVE_ANIMATION");
                    material.DisableKeyword("_EMISSIVE_SIMPLE");
                }
                else
                {
                    material.SetFloat("_EMISSIVE", 0);
                    material.EnableKeyword("_EMISSIVE_SIMPLE");
                    material.DisableKeyword("_EMISSIVE_ANIMATION");
                }
            }



            EditorGUI.BeginDisabledGroup(m_emissionMode != EmissionMode.EmissiveAnimation);
            {
                EditorGUI.indentLevel++;

                GUI_FloatProperty(material, Styles.baseSpeedText);
                if (!_SimpleUI)
                {
                    int mode = MaterialGetInt(material, ShaderPropIs_ViewCoord_Scroll);
                    EditorGUI.BeginChangeCheck();
                    mode = EditorGUILayout.Popup(Styles.emissiveScrollAnimationModeText, (int)mode, EmissiveScrollMode);
                    if (EditorGUI.EndChangeCheck())
                    {
                        m_MaterialEditor.RegisterPropertyChangeUndo(Styles.emissiveScrollAnimationModeText.text);
                        MaterialSetInt(material, ShaderPropIs_ViewCoord_Scroll, mode);
                    }
                }

                
                GUI_RangeProperty(material, Styles.scrollEmissiveUText);
                GUI_RangeProperty(material, Styles.scrollEmissiveVText);
                GUI_FloatProperty(material, Styles.rotateEmissiveUVText);

                GUI_Toggle(material, Styles.pingpongMoveText, ShaderPropIs_PingPong_Base, MaterialGetInt(material, ShaderPropIs_PingPong_Base) != 0);


                if (!_SimpleUI)
                {
                    EditorGUILayout.Space();

                    //GUILayout.Space(60);
                    var isColorShiftEnabled = GUI_Toggle(material, Styles.colorShitWithTimeText, ShaderPropIs_ColorShift, MaterialGetInt(material, ShaderPropIs_ColorShift) != 0 );


                    EditorGUI.indentLevel++;
                    EditorGUI.BeginDisabledGroup(!isColorShiftEnabled);
                    {
                        GUI_ColorProperty(material, Styles.colorShiftText);
                        GUI_FloatProperty(material, Styles.colorShiftSpeedText);
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUI.indentLevel--;

                    EditorGUILayout.Space();

                    var isViewShiftEnabled = GUI_Toggle(material, Styles.colorShiftWithViewAngle, ShaderPropIs_ViewShift, MaterialGetInt(material, ShaderPropIs_ViewShift) != 0);


                    EditorGUI.indentLevel++;
                    EditorGUI.BeginDisabledGroup(!isViewShiftEnabled);
                    GUI_ColorProperty(material, Styles.viewShiftText);
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.indentLevel--;
                }//!_SimpleUI
                EditorGUI.indentLevel--;
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();

        }


        const string srpDefaultColorMask = "_SPRDefaultUnlitColorMask";
        const string srpDefaultCullMode = "_SRPDefaultUnlitColMode";

        internal static void SetupOverDrawTransparentObject(Material material)
        {
            var srpDefaultLightModeTag = material.GetTag("LightMode", false, srpDefaultLightModeName);
            if (srpDefaultLightModeTag == srpDefaultLightModeName)
            {
                material.SetShaderPassEnabled(srpDefaultLightModeName, true);
                MaterialSetInt(material, srpDefaultColorMask, 0);
                MaterialSetInt(material, srpDefaultCullMode, (int)CullingMode.Backface);
            }
        }
        internal static void SetupOutline(Material material)
        {
            var srpDefaultLightModeTag = material.GetTag("LightMode", false, srpDefaultLightModeName);
            if (srpDefaultLightModeTag == srpDefaultLightModeName)
            {
                MaterialSetInt(material, srpDefaultColorMask, 15);
                MaterialSetInt(material,srpDefaultCullMode, (int)CullingMode.Frontface);
            }
        }
        void GUI_Outline(Material material)
        {
            const string kDisableOutlineKeyword = "_DISABLE_OUTLINE";
            bool isLegacy = (srpDefaultLightModeName == "Always");

            var srpDefaultLightModeTag = material.GetTag("LightMode", false, srpDefaultLightModeName);
            bool isOutlineEnabled = true;
            if (srpDefaultLightModeTag == srpDefaultLightModeName)
            {
                const string kOutline = "Outline";
                isOutlineEnabled = material.GetShaderPassEnabled(srpDefaultLightModeName);

                EditorGUI.BeginChangeCheck();
                isOutlineEnabled = EditorGUILayout.Toggle(kOutline, isOutlineEnabled);
                if (EditorGUI.EndChangeCheck())
                {
                    m_MaterialEditor.RegisterPropertyChangeUndo(kOutline);
                    if (isOutlineEnabled)
                    {
                        if (isLegacy)
                        {
                            material.DisableKeyword(kDisableOutlineKeyword);
                        }

                        material.SetShaderPassEnabled(srpDefaultLightModeName, true);
                    }
                    else
                    {
                        if (isLegacy)
                        {
                            material.EnableKeyword(kDisableOutlineKeyword);
                        }
                        material.SetShaderPassEnabled(srpDefaultLightModeName, false);
                    }
                }
            }
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(!isOutlineEnabled);
            //
            //Express Shader property [KeywordEnum(NML,POS)] by EumPopup.
            //Load the outline mode settings in the material.
            int _OutlineMode_Setting = MaterialGetInt(material,ShaderPropOutline);
            //Convert it to Enum format and store it in the offlineMode variable.

            if ((int)OutlineMode.NormalDirection == _OutlineMode_Setting)
            {
                m_outlineMode = OutlineMode.NormalDirection;
            }
            else if ((int)OutlineMode.PositionScaling == _OutlineMode_Setting)
            {
                m_outlineMode = OutlineMode.PositionScaling;
            }
            //GUI description with EnumPopup.
            m_outlineMode = (OutlineMode)EditorGUILayout.EnumPopup(Styles.outlineModeText, m_outlineMode);
            //If the value changes, write to the material.
            if (m_outlineMode == OutlineMode.NormalDirection)
            {
                material.SetFloat(ShaderPropOutline, 0);
                //The keywords on the UTCS_Outline.cginc side are also toggled around.
                material.EnableKeyword("_OUTLINE_NML");
                material.DisableKeyword("_OUTLINE_POS");
            }
            else if (m_outlineMode == OutlineMode.PositionScaling)
            {
                material.SetFloat(ShaderPropOutline, 1);
                material.EnableKeyword("_OUTLINE_POS");
                material.DisableKeyword("_OUTLINE_NML");
            }

            GUI_FloatProperty(material, Styles.outlineWidthText);
            GUI_ColorProperty(material, Styles.outlineColorText);

            GUI_Toggle(material, Styles.baseColorToOtulineText, ShaderPropIs_BlendBaseColor, MaterialGetInt(material, ShaderPropIs_BlendBaseColor) != 0);

            m_MaterialEditor.TexturePropertySingleLine(Styles.outlineSamplerText, outline_Sampler);
            GUI_FloatProperty(material, Styles.offsetZText);

            if (!_SimpleUI)
            {
                EditorGUILayout.Space();
                //                _AdvancedOutline_Foldout = FoldoutSubMenu(_AdvancedOutline_Foldout, Styles.AdvancedOutlineFoldout);
                //                if (_AdvancedOutline_Foldout)
                {

                    EditorGUILayout .LabelField("Camera Distance for Outline Width");
                    EditorGUI.indentLevel++;
                    GUI_FloatProperty(material, Styles.farthestDistanceText);
                    GUI_FloatProperty(material, Styles.nearestDistanceText);
                    EditorGUI.indentLevel--;

                    var useOutlineTexture =  GUI_Toggle(material, Styles.outlineColorMapText, ShaderPropIs_OutlineTex, MaterialGetInt(material, ShaderPropIs_OutlineTex)!=0); ;
                    EditorGUI.BeginDisabledGroup(!useOutlineTexture);
                    m_MaterialEditor.TexturePropertySingleLine(Styles.outlineTexText, outlineTex);
                    EditorGUI.EndDisabledGroup();
                    EditorGUI.BeginDisabledGroup(m_outlineMode != OutlineMode.NormalDirection);
                    {
                        var isBackedNormal = GUI_Toggle(material, Styles.bakedNormalForOutlineText, ShaderPropIs_BakedNormal, MaterialGetInt(material, ShaderPropIs_BakedNormal) != 0);
                        EditorGUI.BeginDisabledGroup(!isBackedNormal);
                        m_MaterialEditor.TexturePropertySingleLine(Styles.bakedNormalOutlineText, bakedNormal);
                        EditorGUI.EndDisabledGroup();
                    }
                    EditorGUI.EndDisabledGroup();
                }
                EditorGUI.EndDisabledGroup(); //!isOutlineEnabled
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
        }

        void GUI_Tessellation(Material material)
        {
            GUI_RangeProperty(material, Styles.legacyTessEdgeLengthText);
            GUI_RangeProperty(material, Styles.legacyTessPhongStrengthText);
            GUI_RangeProperty(material, Styles.legacyTessExtrusionAmountText);

            EditorGUILayout.Space();
        }



        void GUI_LightColorEffectiveness(Material material)
        {
            EditorGUILayout.LabelField(Styles.lightColorEffectiveness);
            EditorGUI.indentLevel++;
            GUI_Toggle(material, Styles.lightColorEffectivinessToBaseColorText, ShaderPropIsLightColor_Base, MaterialGetInt(material, ShaderPropIsLightColor_Base)!= 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessTo1stShadingText, ShaderPropIs_LightColor_1st_Shade, MaterialGetInt(material, ShaderPropIs_LightColor_1st_Shade) != 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessTo2ndShadingText, ShaderPropIs_LightColor_2nd_Shade, MaterialGetInt(material, ShaderPropIs_LightColor_2nd_Shade) != 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessToHighlitText, ShaderPropIs_LightColor_HighColor, MaterialGetInt(material, ShaderPropIs_LightColor_HighColor) != 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessToRimlitText, ShaderPropIs_LightColor_RimLight, MaterialGetInt(material, ShaderPropIs_LightColor_RimLight) != 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessToInvRimlitText, ShaderPropIs_LightColor_Ap_RimLight, MaterialGetInt(material, ShaderPropIs_LightColor_Ap_RimLight) != 0);

            EditorGUI.BeginDisabledGroup(m_WorkflowMode != UTS_Mode.ShadingGradeMap);
            {
                GUI_Toggle(material, Styles.lightColorEffectivenessToAngelRingText, ShaderPropIs_LightColor_AR, MaterialGetInt(material, ShaderPropIs_LightColor_AR) != 0);
            }
            EditorGUI.EndDisabledGroup();

            GUI_Toggle(material, Styles.lightColorEffectivinessToMatCapText, ShaderPropIs_LightColor_MatCap, MaterialGetInt(material, ShaderPropIs_LightColor_MatCap) != 0);
            GUI_Toggle(material, Styles.lightColorEffectivinessToOutlineText, ShaderPropIs_LightColor_Outline, MaterialGetInt(material, ShaderPropIs_LightColor_Outline) != 0);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            GUI_RangeProperty(material, Styles.giIntensityText);

            EditorGUI.BeginChangeCheck();
            var prop = ShaderPropIs_Filter_LightColor;

            var value = MaterialGetInt(material, prop);
            var ret = EditorGUILayout.Toggle(Styles.limitLightIntensityText.text, value != 0);
            if (EditorGUI.EndChangeCheck())
            {
                var boolValue = ret ? 1 : 0;
                m_MaterialEditor.RegisterPropertyChangeUndo(Styles.limitLightIntensityText.text);
                MaterialSetInt(material, prop, boolValue);
                if (boolValue != 0)
                {
                    MaterialSetInt(material, ShaderPropIs_Filter_LightColor, boolValue);
                    MaterialSetInt(material, ShaderPropIsLightColor_Base, boolValue);
                    MaterialSetInt(material, ShaderPropIs_LightColor_1st_Shade, boolValue);
                    MaterialSetInt(material, ShaderPropIs_LightColor_2nd_Shade, boolValue);
                    if (material.HasProperty(ShaderPropOutline))//If OUTLINE is available.
                    {
                        MaterialSetInt(material, ShaderPropIs_LightColor_Outline, boolValue);
                    }
                }
            }
            EditorGUILayout.Space();
        }

        void GUI_MetaverseSettings(Material material)
        {
            float isMetaverseLightEnabled = material.GetFloat(ShaderPropUnlit_Intensity);
            isMetaverseLightEnabled = GUI_Toggle(material, Styles.metaverseLightText, ShaderPropUnlit_Intensity, isMetaverseLightEnabled != 0) ? 1: 0;
            EditorGUI.BeginDisabledGroup(isMetaverseLightEnabled == 0);
            {
                EditorGUI.indentLevel++;
                GUI_RangeProperty(material, Styles.metaverseRangePropText);

                var isBold = GUI_Toggle(material, Styles.metaverseLightDirectionText, ShaderPropIs_BLD, MaterialGetInt(material, ShaderPropIs_BLD) != 0);
                EditorGUI.BeginDisabledGroup(!isBold);

                EditorGUI.indentLevel++;
                GUI_RangeProperty(material, Styles.metaverseOffsettXaxisText);
                GUI_RangeProperty(material, Styles.metaverseOffsettYaxisText);

                GUI_Toggle(material, Styles.invertZaxisDirection, ShaderPropInverse_Z_Axis_BLD, MaterialGetInt(material, ShaderPropInverse_Z_Axis_BLD) != 0);

                EditorGUI.indentLevel--;
                EditorGUI.EndDisabledGroup();
                EditorGUI.indentLevel--;
            }
            EditorGUI.EndDisabledGroup();

        }

        public void DoPopup(GUIContent label, MaterialProperty property, string[] options)
        {
            DoPopup(label, property, options, m_MaterialEditor);
        }

        public static void DoPopup(GUIContent label, MaterialProperty property, string[] options, MaterialEditor materialEditor)
        {
            if (property == null)
                throw new System.ArgumentNullException("property");

            EditorGUI.showMixedValue = property.hasMixedValue;

            var mode = property.floatValue;

            EditorGUI.BeginChangeCheck();
            mode = EditorGUILayout.Popup(label, (int)mode, options);
            if (EditorGUI.EndChangeCheck())
            {
                materialEditor.RegisterPropertyChangeUndo(label.text);
                property.floatValue = mode;
            }

            EditorGUI.showMixedValue = false;
        }


    } 


}
