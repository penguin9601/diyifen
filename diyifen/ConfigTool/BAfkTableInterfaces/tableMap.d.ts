interface ITBase<T> { [key:string]:T}
interface IT_TableMap {
	readonly GameConfigSetting?: ITBase<IT_GameConfigSetting>;
	readonly LanguageSetting?: ITBase<IT_LanguageSetting>;
	readonly LanguageTypeSetting?: ITBase<IT_LanguageTypeSetting>;
}
interface IT_GameConfigSetting {
	/** 主键 */
	readonly id?: number;
	/** 键 */
	readonly key?: string;
	/** 值 */
	readonly value?: string;
}
interface IT_LanguageSetting {
	/** 主键 */
	readonly id?: string;
	/** 中文 */
	readonly cn?: string;
	/** 英文 */
	readonly en?: string;
}
interface IT_LanguageTypeSetting {
	/** 主键 */
	readonly id?: number;
	/** 类型 */
	readonly type?: string;
	/** 描述 */
	readonly desc?: string;
}
